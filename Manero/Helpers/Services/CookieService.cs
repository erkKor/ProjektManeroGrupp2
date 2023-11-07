namespace Manero.Helpers.Services
{
    public interface ICookieService
    {
        void SetWelcomeCookie(HttpContext httpContext);
    }

    public class CookieService : ICookieService
    {
        public void SetWelcomeCookie(HttpContext httpContext)
        {
            var existingCookie = httpContext.Request.Cookies["hasSeenWelcome"];
            if (existingCookie == null)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddYears(1),
                    Path = "/"
                };
                httpContext.Response.Cookies.Append("hasSeenWelcome", "true", cookieOptions);
            }
        }
    }
}
