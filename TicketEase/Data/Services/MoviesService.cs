using Microsoft.EntityFrameworkCore;
using TicketEase.Data.Base;
using TicketEase.Data.ViewModels;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMoivie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                CinemaId = data.CinemaId,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId,
            };
            _context.Movies.AddAsync(newMoivie);
            await _context.SaveChangesAsync();

            // Add actors Movie

            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMoivie.Id,
                    ActorId = actorId,
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieNyIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c =>c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;

        }

        public async Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues()
        {
            var response = new NewMovieDropDownsVM()
            {
               Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
               Cinemas = await _context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
               Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync(),
            };
            return response;
        }
    }
}
