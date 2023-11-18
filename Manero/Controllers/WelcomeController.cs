using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class WelcomeController : Controller
    {
        public IActionResult Index()
        {
            // Checks the cookies if it has a "hasSeenWelcome" cookie
            if (!Request.Cookies.ContainsKey("hasSeenWelcome"))
            {
                // Set the "hasSeenWelcome" cookie to indicate that the user has seen the welcome page
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1), // Cookie lasts for 1 year
                    Path = "/"  //What pages the cookie is available from / meaning all
                };
                // Add cookie "hasSeenWelcome"
                Response.Cookies.Append("hasSeenWelcome", "true", cookieOptions);
            }
            return View();
        }
    }
}
