using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketEase.Data;
using TicketEase.Data.Services;
using TicketEase.Models;

namespace TicketEase.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducersService _service;

        public ProducersController(IProducersService service)
        {
            _service = service;
        }
        // Action method pour l'affichage de la page Index des acteurs
        // Lorsqu'un utilisateur accède à l'URL correspondant à cette action, cette méthode est appelée
        // La méthode est marquée comme asynchrone, ce qui permet d'effectuer des opérations asynchrones sans bloquer le thread principal
        public async Task<IActionResult> Index()
        {
            // Récupère tous les producteurs à partir de la base de données de manière asynchrone
            // La méthode ToListAsync() exécute la requête de manière asynchrone et retourne les résultats sous forme de liste
            var AllProduers = await _service.GetAllAsync();

            // Une fois que la liste des producteurs est récupérée, elle peut être utilisée pour effectuer d'autres opérations ou être transmise à la vue
            // Retourne la vue par défaut pour l'Index des acteurs, en transmettant éventuellement la liste des producteurs à la vue
            // La vue associée à cette action sera recherchée dans le dossier Views/Actors (par convention)
            return View(AllProduers);
        }

        // GET : producers/details/1
        public async Task<IActionResult> Details(int id)
        {
            var productDetails = await _service.GetByIdAsync(id);
            if(productDetails == null)
            {
                return View("NotFound");
            }
            return View(productDetails);
        }
        // GET : producers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Biographie")]Producer producer)
        {
            if(!ModelState.IsValid) return View(producer);
            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }

        // GET : producers/edit/2
        public async Task<IActionResult> Edit(int id)
        {
            var producersDetails = await _service.GetByIdAsync(id);
            if(producersDetails == null) { return View("NotFound"); }
            return View(producersDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Biographie")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            if(id == producer.Id)
            {
                await _service.UpdateAsync(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
    }
}
