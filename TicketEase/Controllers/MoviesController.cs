using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketEase.Data;

namespace TicketEase.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var AllMovies = await _context.Movies.ToListAsync();
            return View();
        }
    }
}
