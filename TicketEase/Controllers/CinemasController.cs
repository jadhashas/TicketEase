using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketEase.Data;

namespace TicketEase.Controllers
{
    public class CinemasController : Controller
    {
        private readonly AppDbContext _context;

        public CinemasController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var AllCinemas = await _context.Cinemas.ToListAsync();
            return View(AllCinemas);
        }
    }
}
