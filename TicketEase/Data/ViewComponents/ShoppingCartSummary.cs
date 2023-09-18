using Microsoft.AspNetCore.Mvc;
using TicketEase.Data.Cart;

namespace TicketEase.Data.ViewComponents
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly ShoppingCart _ShoppingCart;

        public ShoppingCartSummary(ShoppingCart ShoppingCart)
        {
            _ShoppingCart = ShoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _ShoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
