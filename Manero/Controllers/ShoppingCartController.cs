using Manero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Manero.Controllers
{
    public class ShoppingCartController : Controller
    {
        private List<CartItem> GetCartFromSession()
        {
            string jsonCart = HttpContext.Session.GetString("CartItems");
            if (jsonCart != null)
            {
                return JsonSerializer.Deserialize<List<CartItem>>(jsonCart);
            }
            return new List<CartItem>();
        }

        public IActionResult Index()
        {
            List<CartItem> cartItems = GetCartFromSession();
            return View(cartItems);
        }

        public ActionResult AddToCart(int id, string name, decimal price, int quantity)
        {
            List<CartItem> cartItems = GetCartFromSession();

            CartItem existingItem = cartItems.FirstOrDefault(item => item.Id == id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                });
            }
            SaveCartToSession(cartItems);

            return RedirectToAction("Index");
        }

    }
}
