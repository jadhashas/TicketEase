using TicketEase.Data.Base;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, IMoviesService
    {
        public MoviesService(AppDbContext context) : base(context) { }
    }
}
