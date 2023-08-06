using Microsoft.AspNetCore.Mvc;
using TicketEase.Data;
using TicketEase.Data.Services;

namespace TicketEase.Controllers
{
    // Définition du contrôleur ActorsController, qui hérite de la classe Controller
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        // Action method pour l'affichage de la page Index des acteurs
        // Lorsqu'un utilisateur accède à l'URL correspondant à cette action, cette méthode est appelée
        // IActionResult est utilisé pour renvoyer une vue ou une autre réponse HTTP appropriée
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
            // Cette action retourne simplement la vue par défaut pour l'Index des acteurs
            // La vue associée à cette action sera recherchée dans le dossier Views/Actors (par convention)
            return View(data);
        }
        // Get : Actors/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
