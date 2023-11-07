using Manero.Helpers.Repositories;
using Manero.Models;
using Manero.Models.Entities;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace Manero.Helpers.Services
{
    public class ShoppingCartService
    {
        private const string SessionKey = "CartItems";
        private const string LocalStorageKey = "LocalCartItems";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ShoppingCartRepository _shoppingCartRepo;
        private readonly CartItemRepository _cartItemRepo;

        public ShoppingCartService(IHttpContextAccessor httpContextAccessor, ShoppingCartRepository shoppingCartRepo, CartItemRepository cartItemRepo)
        {
            _httpContextAccessor = httpContextAccessor;
            _shoppingCartRepo = shoppingCartRepo;
            _cartItemRepo = cartItemRepo;
        }


        public void SaveCartToLocal(List<CartItem> cartItems)
        {
            if (cartItems != null)
            {
                string jsonCart = JsonSerializer.Serialize(cartItems);
                _httpContextAccessor.HttpContext!.Response.Cookies.Append("LocalStorageKey", jsonCart, new CookieOptions
                {
                    IsEssential = true, // Ensures the cookie will be stored even if the user denies cookies
                    Expires = DateTimeOffset.UtcNow.AddMinutes(30) 
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

        public async Task<List<CartItem>> GetCartItemsFromDBAsync()
        {
            var cartItemsEntities = await _cartItemRepo.GetAllAsync();
            List<CartItem> cartItems = new List<CartItem>();
            foreach (var entity in cartItemsEntities)
            {
                // Convert CartItemEntity to CartItem
                CartItem cartItem = new CartItem
                {
                    Id = entity.ProductId,
                    Name = entity.Name,
                    Color = entity.Color,
                    Price = entity.Price,
                    Quantity = entity.Quantity,
                    Size = entity.Size,
                };

                cartItems.Add(cartItem);
            }
            return cartItems;
        }
            public async Task SaveCartToDB(string id)
        {

            var shoppingCart = await _shoppingCartRepo.GetAsync(x => x.UserId == id);
            // If Cart doesn't exist, create a new cart
            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCartEntity
                {
                    UserId = id
                };
            }

            var cartItems = GetCartFromLocal();
            if(cartItems.Count == 0) 
                // If there are no items in local cart, get from Database
                cartItems = await GetCartItemsFromDBAsync();

            if(cartItems != null)
            {
                foreach (var item in cartItems)
                {
                    var existingCartItem = shoppingCart.Items.FirstOrDefault(x => x.Name == item.Name && x.Color == item.Color && x.Size == item.Size);
                    if (existingCartItem != null)
                    {
                        // Update existing cart item if found
                        existingCartItem.Price = item.Price;
                        existingCartItem.Quantity = item.Quantity;
                    }
                    else
                    {
                        // Create a new cart item and add it to the shopping cart
                        var cartItemEntity = new CartItemEntity
                        {
                            Name = item.Name,
                            Color = item.Color,
                            Size = item.Size,
                            Price = item.Price,
                            Quantity = item.Quantity
                        };

                        shoppingCart.Items.Add(cartItemEntity); // Add new cart item to the shopping cart
                    }
                }
            }

            // Save the updated/created shoppingCart to the database using your repository
            if (shoppingCart.ShoppingCartId != 0)
                await _shoppingCartRepo.UpdateShoppingCartWithItemsAsync(shoppingCart); // Update existing cart
            else        
                await _shoppingCartRepo.AddShoppingCartWithItemsAsync(shoppingCart); // Add new cart
        }

    }
}