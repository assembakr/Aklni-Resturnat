using AklniResturant.Data;
using AklniResturant.Interfaces;
using AklniResturant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AklniResturant.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepository<Product> _products;
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "Cart";

        public CartController(IRepository<Product> products, ApplicationDbContext context)
        {
            _products = products;
            _context = context;
        }

        private string? GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // Display the cart
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();

            if (userId != null)
            {
                var cart = await _context.UserCarts
                    .Include(c => c.Items)
                    .ThenInclude(i => i.Product)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cart == null)
                    cart = new UserCart { UserId = userId, Items = new List<UserCartItem>() };

                return View(cart.Items);
            }
            else
            {
                var cart = HttpContext.Session.Get<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();
                return View(cart);
            }
        }

        // Add to cart
        [HttpGet]
        public async Task<IActionResult> AddToCart(int productId, int quantity = 1)
        {
            var product = await _products.GetByIdAsync(productId, new Query<Product>());
            if (product == null)
                return NotFound();

            var userId = GetUserId();

            if (userId != null)
            {
                // Logged-in user - DB cart
                var cart = await _context.UserCarts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.UserId == userId)
                    ?? new UserCart { UserId = userId };

                var existing = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (existing != null)
                    existing.Quantity += quantity;
                else
                    cart.Items.Add(new UserCartItem
                    {
                        ProductId = product.ProductId,
                        Quantity = quantity,
                        UnitPrice = (double)product.Price
                    });

                _context.Update(cart);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Guest - session cart
                var cart = HttpContext.Session.Get<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();
                var existing = cart.FirstOrDefault(i => i.ProductId == product.ProductId);

                if (existing != null)
                    existing.Quantity += quantity;
                else
                    cart.Add(new OrderItem
                    {
                        ProductId = product.ProductId,
                        Product = product,
                        Quantity = quantity,
                        UnitPrice = product.Price
                    });

                HttpContext.Session.Set(CartSessionKey, cart);
            }

            return RedirectToAction("Index");
        }

        // Remove item
        [HttpPost]
        public async Task<IActionResult> Remove(int productId)
        {
            var userId = GetUserId();

            if (userId != null)
            {
                var cart = await _context.UserCarts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cart != null)
                {
                    var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                    if (item != null)
                    {
                        cart.Items.Remove(item);
                        _context.Update(cart);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            else
            {
                var cart = HttpContext.Session.Get<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();
                var item = cart.FirstOrDefault(c => c.ProductId == productId);

                if (item != null)
                {
                    cart.Remove(item);
                    HttpContext.Session.Set(CartSessionKey, cart);
                }
            }

            return RedirectToAction("Index");
        }

        // Clear all
        [HttpGet]
        public async Task<IActionResult> Clear()
        {
            var userId = GetUserId();

            if (userId != null)
            {
                var cart = await _context.UserCarts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cart == null || !cart.Items.Any())
                {
                    TempData["Message"] = "Your cart is already empty!";
                    return RedirectToAction("Index");
                }

                return View(cart.Items);
            }
            else
            {
                var cart = HttpContext.Session.Get<List<OrderItem>>(CartSessionKey) ?? new List<OrderItem>();
                if (!cart.Any())
                {
                    TempData["Message"] = "Your cart is already empty!";
                    return RedirectToAction("Index");
                }

                return View(cart);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearConfirmed()
        {
            var userId = GetUserId();

            if (userId != null)
            {
                var cart = await _context.UserCarts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.UserId == userId);

                if (cart != null)
                {
                    _context.UserCartItems.RemoveRange(cart.Items);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                HttpContext.Session.Remove(CartSessionKey);
            }

            TempData["Message"] = "Your cart has been cleared!";
            return RedirectToAction("Index");
        }
    }
}
