using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketEase.Data;
using TicketEase.Data.Services;

namespace TicketEase.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var AllMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(AllMovies);
        }
    }
}
