using Microsoft.AspNetCore.Mvc;
using CineManagerWeb.Models;

public class CinemaController : Controller
{
    // La lista è statica per non perdere i dati tra i click
    private static List<Sala> _sale = new List<Sala> {
        new Sala { Id = 1, Film = "Il Glossario", Disponibilita = 20},
        new Sala { Id = 2, Film = "C# Revenge", Disponibilita = 5 }
    };

    public IActionResult Index()
    {
        return View(_sale); // Invia la lista alla pagina HTML
    }

    public IActionResult Admin()
    {
        return View(_sale); // Invia la lista alla pagina HTML
    }

    public IActionResult Prenota(int id)
    {
        var sala = _sale.Find(s => s.Id == id);
        if (sala != null) sala.OccupaPosto();
        return RedirectToAction("Index"); // Ricarica la pagina
    }

    public IActionResult PrenotaAdmin(int id)
    {
        var sala = _sale.Find(s => s.Id == id);
        if (sala != null) sala.OccupaPosto();
        return RedirectToAction("Admin");
    }

    public IActionResult DisdiciAdmin(int id)
    {
        var sala = _sale.Find(s => s.Id == id);
        if (sala != null) sala.DisdiciPosto();
        return RedirectToAction("Admin"); //prima era così: return RedirectToAction("Index", "Admin");
    }
}
