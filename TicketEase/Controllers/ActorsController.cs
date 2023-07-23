using Microsoft.AspNetCore.Mvc;
using TicketEase.Data;

namespace TicketEase.Controllers
{
    // Définition du contrôleur ActorsController, qui hérite de la classe Controller
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;
        public ActorsController(AppDbContext context)
        {
            _context = context;
        }
        // Action method pour l'affichage de la page Index des acteurs
        // Lorsqu'un utilisateur accède à l'URL correspondant à cette action, cette méthode est appelée
        // IActionResult est utilisé pour renvoyer une vue ou une autre réponse HTTP appropriée
        public IActionResult Index()
        {
            var data = _context.Actors.ToList();
            // Cette action retourne simplement la vue par défaut pour l'Index des acteurs
            // La vue associée à cette action sera recherchée dans le dossier Views/Actors (par convention)
            return View();
        }
    }
}
