﻿using Microsoft.AspNetCore.Mvc;
using TicketEase.Data.Cart;
using TicketEase.Data.Services;
using TicketEase.Data.ViewModels;

namespace TicketEase.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IMoviesService _moviesService;
		private readonly ShoppingCart _shoppingCart;
        public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart)
        {
            _moviesService = moviesService;
			_shoppingCart = shoppingCart;
        }
        public IActionResult Index()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			var response = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
			};
			return View(response);
		}
	}
}
