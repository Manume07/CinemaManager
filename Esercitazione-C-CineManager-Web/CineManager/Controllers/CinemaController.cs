using Microsoft.AspNetCore.Mvc;
using CineManagerWeb.Models;
using System.Text.Encodings.Web;

public class CinemaController : Controller
{
    // La lista è statica per non perdere i dati tra i click
    private static List<Sala> _sale = new List<Sala> {
        new Sala { Id = 1, Film = "Il Glossario", PostiLiberi = 20, Posti = 20, PostiOccupati = 0},
        new Sala { Id = 2, Film = "C# Revenge", PostiLiberi = 5, Posti = 5, PostiOccupati = 0 }
    };

    public IActionResult Index()
    {
        return View(_sale); // Invia la lista alla pagina HTML
    }

    public IActionResult Prenota(int id)
    {
        var sala = _sale.Find(s => s.Id == id);
        if (sala != null) sala.OccupaPosto();
        return RedirectToAction("Index"); // Ricarica la pagina
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string username, string password)
    {
        if (username == "administrator" && password == "password")
        {
            // Autenticazione riuscita, puoi impostare una sessione o un cookie qui
            var options = new CookieOptions
            {
                HttpOnly = false, // false se vuoi leggerlo da JS; true per sicurezza in produzione
                Secure = false,   // usa true in produzione (HTTPS). Metti false in sviluppo su HTTP.
                SameSite = SameSiteMode.Lax,
                Path = "/"
            };
            Response.Cookies.Append("UserSession", "administrator", options);
            return RedirectToAction("Index");
        }
        return RedirectToAction("Index");
    }

    public IActionResult Disdici(int id)
    {
        var sala = _sale.Find(s => s.Id == id);
        if (sala != null && sala.PostiOccupati != 0) sala.DisdiciPosto();
        return RedirectToAction("Index"); // Ricarica la pagina
    }

    public IActionResult CambiaCapienza(int id, int nuovacapienza)
    {
        var sala = _sale.Find(s => s.Id == id);
        if (sala != null && nuovacapienza > 0) sala.CambiaPosti(nuovacapienza);
        return RedirectToAction("Index"); // Ricarica la pagina
    }

    public IActionResult Alert(string msg)
    {
        
        TempData["AlertMessage"] = msg;
        return RedirectToAction("Index");
    }
    public IActionResult Omaggio(int id, string NuovoOmaggio)
    {
        var sala = _sale.Find(s => s.Id == id);
        if (NuovoOmaggio == "V4CC4R1")
        {
            if (sala.PostiLiberi > 0)
            {
                sala.OccupaPosto();
                TempData["AlertMessage"] = "Omaggio riscattato! Posto occupato gratuitamente";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["AlertMessage"] = "Mi dispiace, non ci sono posti liberi per l'omaggio";
                return RedirectToAction("Index");
            }
        }
        else
        {
            TempData["AlertMessage"] = "Codice omaggio non valido";
        }
        return RedirectToAction("Index");
    }
}
