using Microsoft.EntityFrameworkCore;
using TicketEase.Models;

namespace TicketEase.Data.Services
{
	public class OrdersService : IOrdersService
	{
		private readonly AppDbContext _appDbContext;
        public OrdersService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Order>> GetOrdersByIdUserIsAsync(string userId)
		{
			var items = await _appDbContext.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Where(n => n.UserId == userId).ToListAsync();
			return items;
		}

		public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdresse)
		{
			var order = new Order()
			{
				UserId = userId,
				Email = userEmailAdresse
			};
			await _appDbContext.Orders.AddAsync(order);
			await _appDbContext.SaveChangesAsync();
            foreach (var item in items)
            {
				var orderItem = new OrderItem()
				{
					Amount = item.Amount,
					MovieId = item.Movie.Id,
					OrderId = order.Id,
					Price = item.Movie.Price,
				};
				await _appDbContext.OrderItems.AddAsync(orderItem);
            }
			await _appDbContext.SaveChangesAsync();
        }
	}
}
