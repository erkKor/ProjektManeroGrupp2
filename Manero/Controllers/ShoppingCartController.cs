using Manero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;
using Manero.Models.Identity;
using Manero.Helpers.Repositories;

namespace Manero.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _cartService;
        private readonly ShoppingCartRepository _shoppingCartRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public ShoppingCartController(ShoppingCartService cartService, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ShoppingCartRepository shoppingCartRepo)
        {
            _cartService = cartService;
            _signInManager = signInManager;
            _userManager = userManager;
            _shoppingCartRepo = shoppingCartRepo;
        }

        public async Task<IActionResult> Index()
        {
            var cart = new List<CartItem>();
            if (_signInManager.IsSignedIn(User))
            {
                var signedInUserId = _userManager.GetUserId(User);
                if (signedInUserId != null)
                {
                    var shoppingCartId = await _shoppingCartRepo.GetAsync(x => x.UserId == signedInUserId);
                    if (shoppingCartId.ShoppingCartId != 0)
                        cart = await _cartService.GetCartItemsFromDBAsync(shoppingCartId.ShoppingCartId);

                }
            }
            else 
                cart = _cartService.GetCartFromLocal();
            return View(cart);
        }

        [HttpPost]
        public IActionResult Index(string modelData)
        {
            var model = JsonConvert.DeserializeObject<ProductGridItemVM>(modelData);
            if (model != null)
            {
                CartItem cartItem = new CartItem
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = 1 
                };
                var updatedCart = _cartService.AddToCart(cartItem);
                return View(updatedCart);
            }
            return View();
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int itemId, string action)
        {
            List<CartItem> cart = _cartService.GetCartFromLocal();
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

                _cartService.SaveCartToLocal(cart); 
                //Return JSON so the webpage updates quantity with AJAX and does not need to reload page
                return Json(new { newQuantity = item.Quantity });
            }

            return Json(new { error = "Item not found" });
        }
    }
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