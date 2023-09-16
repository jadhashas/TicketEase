using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // GET : Movies/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieNyIdAsync(id);
            return View(movieDetails);
        }

        // GET : Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropDownsData = await _service.GetNewMovieDropDownsValues();

            ViewBag.Cinema = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            ViewBag.Producer = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            return View();
        }
    }
}
