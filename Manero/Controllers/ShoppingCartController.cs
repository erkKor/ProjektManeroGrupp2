using Manero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Newtonsoft.Json;

namespace Manero.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _cartService;

        public ShoppingCartController(ShoppingCartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            List<CartItem> cart = _cartService.GetCartFromLocal();
  

            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(string modelData)
        {
            var model = JsonConvert.DeserializeObject<ProductGridItemVM>(modelData);
            if (model != null)
            {
                CartItem cartItem = new CartItem
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = 1 // You can set a default quantity or leave it for the client to provide
                };
                var updatedCart = _cartService.AddToCart(cartItem);
                return View(updatedCart);
            }

            return View();


            // Perform the necessary logic to convert ProductGridItemVM to CartItem or directly handle it


        }

        [HttpPost]
        public IActionResult UpdateQuantity(int itemId, string action)
        {
            List<CartItem> cart = _cartService.GetCartFromLocal(); // Retrieve the cart from local storage

            CartItem item = cart.FirstOrDefault(i => i.Id == itemId);

            if (item != null)
            {
                if (action == "increment")
                {
                    item.Quantity++;
                }
                else if (action == "decrement" && item.Quantity > 0)
                {
                    item.Quantity--;
                }

                // Find the index of the item in the cart and replace it with the updated one
                int index = cart.FindIndex(i => i.Id == itemId);
                cart[index] = item;

                _cartService.SaveCartToLocal(cart); // Save the updated cart back to local storage

                return Json(new { newQuantity = item.Quantity });
            }

            return Json(new { error = "Item not found" });
        }

        //[HttpPost]
        //public IActionResult IncrementQuantity(int item)
        //{
        //    _cartService.IncrementItemQuantity(item);
        //    // You can redirect or return any response as needed
        //    return RedirectToAction("Index");
        //}

        //// Action method for decrementing the quantity
        //[HttpPost]
        //public IActionResult DecrementQuantity(int item)
        //{
        //    _cartService.DecrementItemQuantity(item);
        //    // You can redirect or return any response as needed
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public IActionResult UpdateQuantity(int itemId, string action)
        //{
        //    CartItem item = _cartService.GetItemFromCart(_cartService.GetCartFromLocal(), itemId); // You should define how to retrieve the cart item

        //    if (item != null)
        //    {
        //        if (action == "increment")
        //        {
        //            item.Quantity++; // Increment the item's quantity
        //            _cartService.IncrementItemQuantity(item.Id);
        //        }
        //        else if (action == "decrement" && item.Quantity > 0)
        //        {
        //            item.Quantity--; // Decrement the item's quantity, ensuring it doesn't go below zero
        //            _cartService.DecrementItemQuantity(item.Id);
        //        }

        //        // Here, you might want to update the cart in the storage/session/database
        //        // Save the cart changes

        //        // Return the updated quantity in JSON format
        //        return Json(new { newQuantity = item.Quantity });
        //    }

        //    // Return an error if the item is not found or other appropriate handling
        //    return Json(new { error = "Item not found" });
        //}
    }
}























//[HttpPost]
//public IActionResult Index(CartItem item)
//{
//    //var cart = _cartService.GetCartFromLocal();
//    //cart.Add(item);

//    //_cartService.SaveCartToLocal(cart);

//    var updatedCart = _cartService.AddToCart(item);

//    return View(updatedCart);

//    //var cart = new List<CartItem>{item};
//    //_cartService.SaveCartToLocal(cart);
//    //return View(cart);
//}

//private List<CartItem> GetCartFromSession()
//{
//    string jsonCart = HttpContext.Session.GetString("CartItems");
//    if (jsonCart != null)
//    {
//        return JsonSerializer.Deserialize<List<CartItem>>(jsonCart);
//    }
//    return new List<CartItem>();
//}

//private void SaveCartToSession(List<CartItem> cartItems)
//{
//    string jsonCart = JsonSerializer.Serialize(cartItems);
//    HttpContext.Session.SetString("CartItems", jsonCart);
//}

//public IActionResult Index()
//{
//    List<CartItem> cartItems = GetCartFromSession();
//    return View(cartItems);
//}

//public ActionResult AddToCart(int id, string name, decimal price, int quantity)
//{
//    List<CartItem> cartItems = GetCartFromSession();

//    CartItem existingItem = cartItems.FirstOrDefault(item => item.Id == id);

//    if (existingItem != null)
//    {
//        existingItem.Quantity += quantity;
//    }
//    else
//    {
//        cartItems.Add(new CartItem
//        {
//            Id = id,
//            Name = name,
//            Price = price,
//            Quantity = quantity
//        });
//    }

//    SaveCartToSession(cartItems);

//    return RedirectToAction("Index");
//}