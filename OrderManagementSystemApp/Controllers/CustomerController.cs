using Microsoft.AspNetCore.Mvc;
using OrderManagementSystemApp.Data;
using OrderManagementSystemApp.Models;

namespace OrderManagementSystemApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly OrderManagementContext _context;

        public CustomerController(OrderManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();
            return View(customers);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
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
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
