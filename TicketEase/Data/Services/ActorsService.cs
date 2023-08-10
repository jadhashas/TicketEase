using Microsoft.EntityFrameworkCore;
using TicketEase.Data.Base;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
	public class ActorsService : EntityBaseRepository<Actor>, IActorsService
	{
		private readonly AppDbContext _context;
		public ActorsService(AppDbContext context) : base(context) {}
    }
}
