using Manero.Helpers.Services;
using Manero.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Manero.Controllers
{
   
        public class ReviewController : Controller
        {
            private readonly ReviewService _reviewService;
            private readonly ProductDetailsService _productService;

            public ReviewController(ReviewService reviewService, ProductDetailsService productDetailsService)
            {
                _reviewService = reviewService;
                _productService = productDetailsService;
            }
            public async Task<IActionResult> Index(int productId)
            {
                var product = await _productService.GetAsync(x => x.ProductId == productId);
                var reviewViewModel = new ReviewViewModel { ProductId = product.ProductId };
                return View(reviewViewModel);
            }

            public async Task<IActionResult> AllReviews(int productId)
            {
                var product = await _productService.GetAsync(x => x.ProductId == productId);
                return View(product);
            }

            [HttpPost]
            public async Task<IActionResult> Index(ReviewViewModel reviewModel)
            {

                // Log the received form data
                Debug.WriteLine($"Received Rating: {reviewModel.Rating}");
                Debug.WriteLine($"Received Text: {reviewModel.Text}");
                Debug.WriteLine($"Received ProductId: {reviewModel.ProductId}");

                if (ModelState.IsValid)
                {

                    var reviewId = await _reviewService.CreateAsync(reviewModel);
                    if (reviewId > 0)
                    {
                        await _reviewService.AddProductReviewAsync(reviewModel.ProductId, reviewId);

                        return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something went wrong");
                    }

                }

                return View(reviewModel);
            }
        }
    
}
