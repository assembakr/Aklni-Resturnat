using AklniResturant.Data;
using AklniResturant.Interfaces;
using AklniResturant.Models;
using AklniResturant.Models.View_Models;
using AklniResturant.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace AklniResturant.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Product> _products;
        private readonly IRepository<Ingredient> _ingredients;
        private readonly IRepository<Category> _categories;
        private readonly IRepository<ProductIngredient> _prodIngredients;

        private readonly IWebHostEnvironment _env;

        public ProductController
        (
            IRepository<Product> _products,
            IRepository<Ingredient> _ingredients,
            IRepository<Category> _categories,
            IRepository<ProductIngredient> _prodIngredients,
            IWebHostEnvironment _env
        )
        {
            this._products = _products;
            this._ingredients = _ingredients;
            this._categories = _categories;
            this._prodIngredients = _prodIngredients;
            this._env = _env;
        }

        // index view to diplay all the products
        public async Task<IActionResult> Index()
        {
            return View(await _products.GetAllAsync());
        }

        // edit view to edit the product only if you are admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var query = new Query<Product>() { Includes = "ProdIngredients.Ingredient" };
            var prod = await _products.GetByIdAsync(id, query);

            if (prod == null)
            {
                return NotFound();
            }
            var vm = new ProductEditVM
            {
                Product = prod,
                Categories = await _categories.GetAllAsync(),
                Ingredients = await _ingredients.GetAllAsync(),
                SelectedIngredientIds = prod.ProdIngredients.Select(p => p.IngredientId).ToArray()
            };
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Ingredients = await _ingredients.GetAllAsync();
                vm.Categories = await _categories.GetAllAsync();
                return View(vm);
            }
            // get the product with ingredients
            var query = new Query<Product> { Includes = "ProdIngredients" };
            var prod = await _products.GetByIdAsync(vm.Product.ProductId, query);

            if (prod == null)
            {
                return NotFound();
            }
            // update fields
            prod.Name = vm.Product.Name;
            prod.Description = vm.Product.Description;
            prod.Price = vm.Product.Price;
            prod.Stock = vm.Product.Stock;
            prod.Category = vm.Product.Category;

            // image upload
            if (vm.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                string fileName = $"{prod.ProductId}{Path.GetExtension(vm.ImageFile.FileName)}";
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await vm.ImageFile.CopyToAsync(fs);
                }

                prod.ImageUrl = $"/images/{fileName}";
            }

            // update ingredients
            prod.ProdIngredients.Clear();
            foreach (var ingredId in vm.SelectedIngredientIds)
            {
                prod.ProdIngredients.Add(new ProductIngredient
                {
                    ProductId = prod.ProductId,
                    IngredientId = ingredId
                });

            }
            await _products.UpdateAsync(prod);
            await _products.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // create view to add product 
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var vm = new ProductEditVM
            {
                Categories = await _categories.GetAllAsync(),
                Ingredients = await _ingredients.GetAllAsync(),
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ProductEditVM vm)
        {
            if (ModelState.IsValid)
            {
                var prod = vm.Product;

                // image upload
                if (prod.ImageFile != null && prod.ImageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                    Directory.CreateDirectory(uploadsFolder);

                    string fileName = $"{Guid.NewGuid()}_{prod.ImageFile.FileName}";
                    string filePath = Path.Combine(uploadsFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await prod.ImageFile.CopyToAsync(stream);
                    }

                    prod.ImageUrl = $"/images/{fileName}";
                }
                await _products.AddAsync(prod);
                await _products.SaveChangesAsync();

                // add selected ingredients
                if (vm.SelectedIngredientIds != null && vm.SelectedIngredientIds.Any())
                {
                    foreach (var ingredientId in vm.SelectedIngredientIds)
                    {
                        var prodIngredient = new ProductIngredient
                        {
                            ProductId = prod.ProductId,
                            IngredientId = ingredientId
                        };
                        await _prodIngredients.AddAsync(prodIngredient);
                    }
                    await _prodIngredients.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            // Refill lists if validation fails
            vm.Categories = (await _categories.GetAllAsync()).ToList();
            vm.Ingredients = (await _ingredients.GetAllAsync()).ToList();

            return View(vm);
        }



        // delete view to delte product
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var query = new Query<Product> { Includes = "Category" };
            var prod = await _products.GetByIdAsync(id, query);

            if (prod == null)
            {
                return NotFound();
            }

            return View(prod);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // get the product 
            var prod = await _products.GetByIdAsync(id, new Query<Product>());
            if (prod == null)
            {
                return NotFound();
            }

            var prodIngredients = await _prodIngredients.GetAllAsync();
            var relatedIngredients = prodIngredients
                .Where(pi => pi.ProductId == id)
                .ToList();


            foreach (var item in relatedIngredients)
            {
                await _prodIngredients.DeleteAsync(item.ProductIngredientId);
            }
            await _prodIngredients.SaveChangesAsync();

            // 4 Delete the image file if it exists
            if (!string.IsNullOrEmpty(prod.ImageUrl))
            {
                var imagePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    prod.ImageUrl.TrimStart('/')
                );

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            //  Delete the product 
            await _products.DeleteAsync(id);
            await _products.SaveChangesAsync();

            //  back to Index
            return RedirectToAction(nameof(Index));
        }

        // add to cart view
        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            return RedirectToAction("AddToCart", "Cart", new { productId, quantity });
        }

    }
}
