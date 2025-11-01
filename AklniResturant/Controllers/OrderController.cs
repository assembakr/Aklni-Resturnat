using AklniResturant.Interfaces;
using AklniResturant.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AklniResturant.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orders;
        private readonly IRepository<OrderItem> _items;

        public OrderController(IRepository<Order> orders, IRepository<OrderItem> items)
        {
            _orders = orders;
            _items = items;
        }

        // checkout view
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.Get<List<OrderItem>>("Cart") ?? new List<OrderItem>();

            if (cart.Count == 0)
            {
                TempData["Message"] = "Your cart is empty!";
                return RedirectToAction("Index", "Cart");
            }

            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmCheckout()
        {
            var cart = HttpContext.Session.Get<List<OrderItem>>("Cart");
            if (cart == null || cart.Count == 0)
            {
                TempData["Message"] = "Your cart is empty!";
                return RedirectToAction("Index", "Cart");
            }

            // Create Order
            var order = new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = (decimal)cart.Sum(i => i.Quantity * i.UnitPrice),
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) // optional if using Identity
            };

            await _orders.AddAsync(order);
            await _orders.SaveChangesAsync(); // order.OrderId now populated

            // Create OrderItems
            foreach (var item in cart)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice
                };

                await _items.AddAsync(orderItem);
            }

            await _items.SaveChangesAsync();

            // Clear Cart
            HttpContext.Session.Remove("Cart");

            TempData["Message"] = "Order placed successfully!";
            return RedirectToAction("Index", "Home");
        }

        // Order Confirmation
        public async Task<IActionResult> OrderConfirmation(int id)
        {
            var order = await _orders.GetByIdAsync(id, new Query<Order>
            {
                Includes = "OrdersItems.Product"
            });

            if (order == null)
                return NotFound();

            return View(order);
        }

    }
}
