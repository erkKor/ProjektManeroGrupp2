using Manero.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Manero.Helpers.Services
{
    public class ShoppingCartService
    {
        private const string SessionKey = "CartItems";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SaveCartToSession(List<CartItem> cartItems)
        {
            if(cartItems != null)
            {
                string jsonCart = JsonSerializer.Serialize(cartItems);
                _httpContextAccessor.HttpContext!.Session.SetString(SessionKey, jsonCart);
            }
        }

        public List<CartItem> GetCartFromSession()
        {
            var jsonCart = _httpContextAccessor.HttpContext!.Session.GetString(SessionKey);
            if (jsonCart != null)
            {
                return JsonSerializer.Deserialize<List<CartItem>>(jsonCart);
            }
            return new List<CartItem>();
        }

        public void AddToCart(int id, string name, decimal price, int quantity)
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
        }
    }
}
