using TicketEase.Data.Base;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieNyIdAsync(int id);
    }
}
