using TicketEase.Data.Base;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context) { }
    }
}
