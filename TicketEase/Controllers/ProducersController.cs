using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketEase.Data;

namespace TicketEase.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context = context;
        }
        // Action method pour l'affichage de la page Index des acteurs
        // Lorsqu'un utilisateur accède à l'URL correspondant à cette action, cette méthode est appelée
        // La méthode est marquée comme asynchrone, ce qui permet d'effectuer des opérations asynchrones sans bloquer le thread principal
        public async Task<IActionResult> Index()
        {
            // Récupère tous les producteurs à partir de la base de données de manière asynchrone
            // La méthode ToListAsync() exécute la requête de manière asynchrone et retourne les résultats sous forme de liste
            var AllProduers = await _context.Producers.ToListAsync();

            // Une fois que la liste des producteurs est récupérée, elle peut être utilisée pour effectuer d'autres opérations ou être transmise à la vue
            // Retourne la vue par défaut pour l'Index des acteurs, en transmettant éventuellement la liste des producteurs à la vue
            // La vue associée à cette action sera recherchée dans le dossier Views/Actors (par convention)
            return View();
        }
    }
}
