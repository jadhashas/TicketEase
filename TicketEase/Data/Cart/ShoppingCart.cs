using Microsoft.EntityFrameworkCore;
using TicketEase.Models;

namespace TicketEase.Data.Cart
{
	public class ShoppingCart
	{
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

		public void AddItemToCart(Movie movie)
		{
			var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
			if(shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItem()
				{
					ShoppingCartId = ShoppingCartId,
					Movie = movie,
					Amount = 1,
				};
				_context.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Amount++;
			}
			_context.SaveChanges();
		}



		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			// Vérifie si la liste ShoppingCartItems est déjà chargée
			// Si ce n'est pas le cas, chargez-la depuis la base de données
			return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
				.Where(n => n.ShoppingCartId == ShoppingCartId) // Sélectionne les éléments du panier pour l'utilisateur actuel
				.Include(n => n.Movie) // Inclut également les données des films associés
				.ToList()); // Renvoie la liste des éléments du panier

			/*SELECT ShoppingCartItems.*, Movies.*
			FROM ShoppingCartItems
			INNER JOIN Movies ON ShoppingCartItems.MovieId = Movies.Id
			WHERE ShoppingCartItems.ShoppingCartId = [votre valeur ShoppingCartId]
			*/
		}

		public double GetShoppingCartTotal()
		{
			// Calcule le total du panier en multipliant le prix de chaque élément par sa quantité et en additionnant le tout
			return _context.ShoppingCartItems
				.Where(n => n.ShoppingCartId == ShoppingCartId) // Sélectionne les éléments du panier pour l'utilisateur actuel
				.Select(n => n.Movie.Price * n.Amount) // Calcule le prix total pour chaque élément (prix du film * quantité)
				.Sum(); // Additionne tous les prix totaux pour obtenir le total du panier

			/*
			SELECT SUM(Movies.Price * ShoppingCartItems.Amount)
			FROM ShoppingCartItems
			INNER JOIN Movies ON ShoppingCartItems.MovieId = Movies.Id
			WHERE ShoppingCartItems.ShoppingCartId = [votre valeur ShoppingCartId]
			*/
		}

	}
}
