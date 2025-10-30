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

        // index view to show all the ingredients
        public async Task<IActionResult> Index()
        {
            return View(await _ingredients.GetAllAsync());
        }

        // details view to display the ingredient details
        public async Task<IActionResult> Details(int id)
        {
            var query = new Query<Ingredient>() { Includes = "ProdIngredients.Product"};
            var ingred = await _ingredients.GetByIdAsync(id, query);

            if (ingred == null)
            {
                return NotFound();
            }
            return View(ingred);
        }


        // create view to add ingredient
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IngredientId,Name")] Ingredient i)
        {
            if (ModelState.IsValid)
            {
                await _ingredients.AddAsync(i);
                await _ingredients.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(i);
        }


        // delete view to delete an ingredient
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new Query<Ingredient>() { Includes = "ProdIngredients.Product" };
            var ingred = await _ingredients.GetByIdAsync(id, query);

            if (ingred == null)
            {
                return NotFound();
            }
            return View(ingred);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Ingredient i)
        {
            await _ingredients.DeleteAsync(i.IngredientId);

            if (i == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
