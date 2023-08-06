using Microsoft.EntityFrameworkCore;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
	public class ActorsService : IActorsService
	{
		private readonly AppDbContext _context;
		public ActorsService(AppDbContext context)
		{
			_context = context;
		}
        public async Task AddAsync(Actor actor)
		{
			await _context.AddAsync(actor);
			await _context.SaveChangesAsync();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}
		// async
		public async Task<IEnumerable<Actor>> GetAll()
		{
			return await _context.Actors.ToListAsync();
		}
		
		public Actor GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Actor Update(int id, Actor actor)
		{
			throw new NotImplementedException();
		}
    }
}
