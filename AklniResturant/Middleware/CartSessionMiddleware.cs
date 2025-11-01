using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace AklniResturant.Middleware
{
    public class CartSessionMiddleware
    {
        private readonly RequestDelegate _next;

        public CartSessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Detect logout 
            if (context.Request.Path.StartsWithSegments("/Identity/Account/Logout"))
            {
                context.Session.Remove("Cart");
            }

            // Detect successful login 
            if (context.Request.Path.StartsWithSegments("/Identity/Account/Login") &&
                context.Request.Method == "POST")
            {
                context.Session.Remove("Cart");
            }

            await _next(context);
        }
    }
}
