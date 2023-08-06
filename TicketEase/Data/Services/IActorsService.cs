using TicketEase.Models;

namespace TicketEase.Data.Services
{
	public interface IActorsService
	{
		Task<IEnumerable<Actor>> GetAllAsync();
		Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);

        Task<Actor> UpdateAsync(int id,Actor actor);

		Task DeleteAsync(int id);
    }
}
