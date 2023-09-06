using TicketEase.Data.Base;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
    public class ProducersService:EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }
    }
}
