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
        public IActionResult Index(string modelData)
        {
            // Perform the necessary logic to convert ProductGridItemVM to CartItem or directly handle it
            ProductGridItemVM model = JsonConvert.DeserializeObject<ProductGridItemVM>(modelData);
            // Example: Convert the received ProductGridItemVM to CartItem
            CartItem cartItem = new CartItem
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Quantity = 1 // You can set a default quantity or leave it for the client to provide
            };

            // Add the converted CartItem to the cart using your service method
            var updatedCart = _cartService.AddToCart(cartItem);

            return View(updatedCart);
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

    }
}




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