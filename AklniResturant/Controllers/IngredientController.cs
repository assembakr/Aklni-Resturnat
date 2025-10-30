using AklniResturant.Data;
using AklniResturant.Models;
using AklniResturant.Repos;
using Microsoft.AspNetCore.Mvc;

namespace AklniResturant.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> _ingredients;

        public IngredientController(ApplicationDbContext cont)
        {
            _ingredients = new Repository<Ingredient>(cont);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _ingredients.GetAllAsync());
        }
    }
}
