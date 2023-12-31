﻿using Microsoft.AspNetCore.Mvc;
using TicketEase.Data;
using TicketEase.Data.Services;
using TicketEase.Models;

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
            var data = await _service.GetAllAsync();
            // Cette action retourne simplement la vue par défaut pour l'Index des acteurs
            // La vue associée à cette action sera recherchée dans le dossier Views/Actors (par convention)
            return View(data);
        }
        // Get : Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Biographie")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        // Get : Actors/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        // Get : Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {

            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Biographie")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                return View(actor);
            }
            await _service.UpdateAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        // Get : Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {

            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
