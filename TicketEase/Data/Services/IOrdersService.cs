using TicketEase.Models;

namespace TicketEase.Data.Services
{
	public interface IOrdersService
	{
		Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdresse);
		Task<List<Order>> GetOrdersByIdUserIsAsync(string userId);
	}
}
