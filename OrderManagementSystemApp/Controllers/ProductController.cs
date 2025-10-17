using Microsoft.AspNetCore.Mvc;
using OrderManagementSystemApp.Data;
using OrderManagementSystemApp.Models;

namespace OrderManagementSystemApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly OrderManagementContext _context;

        public ProductController(OrderManagementContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
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
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
