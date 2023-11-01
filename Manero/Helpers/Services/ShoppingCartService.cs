using Manero.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace Manero.Helpers.Services
{
    public class ShoppingCartService
    {
        private const string SessionKey = "CartItems";
        private const string LocalStorageKey = "LocalCartItems";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }



        public void SaveCartToLocal(List<CartItem> cartItems)
        {
            if (cartItems != null)
            {
                string jsonCart = JsonSerializer.Serialize(cartItems);
                _httpContextAccessor.HttpContext!.Response.Cookies.Append("LocalStorageKey", jsonCart, new CookieOptions
                {
                    IsEssential = true, // Ensures the cookie will be stored even if the user denies cookies
                    Expires = DateTimeOffset.UtcNow.AddMinutes(30) // Set expiration time as desired
                });
            }
        }

        public List<CartItem> GetCartFromLocal()
        {
            var localCartJson = _httpContextAccessor.HttpContext!.Request.Cookies["LocalStorageKey"];
            if (localCartJson != null)
            {
                return JsonSerializer.Deserialize<List<CartItem>>(localCartJson);
            }
            return new List<CartItem>();
        }

        public List<CartItem> AddToCart(CartItem item)
        {
            List<CartItem> cartItems = GetCartFromLocal();

            CartItem existingItem = GetItemFromCart(cartItems, item.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity
                });
            }

            SaveCartToLocal(cartItems);
            return cartItems;
        }

        public CartItem GetItemFromCart(List<CartItem> cart, int itemId)
        {
            return cart.FirstOrDefault(i => i.Id == itemId);
        }

        //private CartItem GetItemFromCart(CartItem item)
        //{
        //    List<CartItem> cartItems = GetCartFromLocal();
        //    CartItem existingItem = cartItems.FirstOrDefault(i => i.Id == item.Id);

        //    if (existingItem != null)
        //    {
        //        existingItem.Quantity += item.Quantity;

        //    }

        //    return cartItems;
        //}


        public void IncrementItemQuantity(int item)
        {
            List<CartItem> cartItems = GetCartFromLocal();
            CartItem existingItem = GetItemFromCart(cartItems, item);

            if (existingItem != null)
            {
                existingItem.Quantity += existingItem.Quantity;
                SaveCartToLocal(cartItems); // Save the updated cart
            }
        }

        public void DecrementItemQuantity(int item)
        {
            List<CartItem> cartItems = GetCartFromLocal();
            CartItem existingItem = GetItemFromCart(cartItems, item);

            if (existingItem != null && existingItem.Quantity > 0)
            {
                existingItem.Quantity -= existingItem.Quantity;
                SaveCartToLocal(cartItems); // Save the updated cart
            }
        }
    }
}




//public void SaveCartToSession(List<CartItem> cartItems)
//{
//    if(cartItems != null)
//    {
//        string jsonCart = JsonSerializer.Serialize(cartItems);
//        _httpContextAccessor.HttpContext!.Session.SetString(SessionKey, jsonCart);
//    }
//}

//public List<CartItem> GetCartFromSession()
//{
//    var jsonCart = _httpContextAccessor.HttpContext!.Session.GetString(SessionKey);
//    if (jsonCart != null)
//    {
//        return JsonSerializer.Deserialize<List<CartItem>>(jsonCart);
//    }
//    return new List<CartItem>();
//}