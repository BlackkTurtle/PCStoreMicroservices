using Microsoft.Extensions.Options;

namespace UserManager.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static void AppendTokenToCookie(this HttpContext context, string token, string userId)
        {

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None, // Required for cross-domain cookies
                Domain = ".localhost", // Allows cookies for all subdomains
                Expires = DateTime.UtcNow.AddMinutes(60)
            };

            context.Response.Cookies.Append("AuthToken", token, cookieOptions);

            context.Response.Cookies.Append("userId", userId, cookieOptions);
        }
    }
}
