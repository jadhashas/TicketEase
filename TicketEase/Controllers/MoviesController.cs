using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketEase.Data;
using TicketEase.Data.Services;
using TicketEase.Models;

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
        // GET : Movie/Create
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid) {
                var movieDropDownsData = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinema = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
                ViewBag.Producer = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDEtails = await _service.GetMovieNyIdAsync(id);
            if (movieDEtails == null)
            {
                return View("NotFound");
            }
            var movieEditable = new NewMovieVM()
            {
                Id = movieDEtails.Id,
                Name = movieDEtails.Name,
                Description = movieDEtails.Description,
                Price = movieDEtails.Price,
                ImageURL = movieDEtails.ImageURL,
                StartDate = movieDEtails.StartDate,
                EndDate = movieDEtails.EndDate,
                CinemaId = movieDEtails.CinemaId,
                MovieCategory = movieDEtails.MovieCategory,
                ProducerId = movieDEtails.ProducerId,
                ActorIds = movieDEtails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };
            var movieDropDownsData = await _service.GetNewMovieDropDownsValues();
            ViewBag.Cinema = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            ViewBag.Producer = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            return View(movieEditable);
        }
        // Movie/Edit/2
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinema = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
                ViewBag.Producer = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
