using Microsoft.AspNetCore.Mvc;

namespace AklniResturant.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
