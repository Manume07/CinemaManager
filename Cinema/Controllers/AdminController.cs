using Microsoft.AspNetCore.Mvc;
using CineManagerWeb.Models;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        // La lista è statica per non perdere i dati tra i click
        private static List<Sala> _sale = new List<Sala> {
            new Sala { Id = 1, Film = "Il Glossario", Disponibilita = 20},
            new Sala { Id = 2, Film = "C# Revenge", Disponibilita = 5 }
        };

        public IActionResult Index()
        {
            // Torna la view esistente in Views/Home/Admin.cshtml
            return View("~/Views/Cinema/Admin.cshtml", _sale);
        }
    }
}
