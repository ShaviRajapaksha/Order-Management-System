using Microsoft.AspNetCore.Mvc;
using OrderManagementSystemApp.Data;
using OrderManagementSystemApp.Models;

namespace OrderManagementSystemApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderManagementContext _context;

        public OrderController(OrderManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }
        // public IActionResult Edit(int id)
        // {
        //     var customer = _context.Customers.Find(id);
        //     if (customer == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(customer);
        // }
        // [HttpPost]
        // [ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            _context.Orders.Remove(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
