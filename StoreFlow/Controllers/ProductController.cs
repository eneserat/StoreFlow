using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.Controllers
{
    public class ProductController:Controller
    {
        private readonly StoreContext _context;

        public ProductController(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var values = _context.Products.ToList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            _context.ProductStockHistories.Add(new ProductStockHistory
            {
                ProductId = product.ProductId,
                ProductStock = product.ProductStock,
                Date = DateTime.Now
            });

            _context.SaveChanges();

            return RedirectToAction("Statistics","Dashboard");
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

            _context.ProductStockHistories.Add(new ProductStockHistory
            {
                ProductId = product.ProductId,
                ProductStock = product.ProductStock,
                Date = DateTime.Now
            });

            _context.SaveChanges();

            return RedirectToAction("Statistics","Dashboard");
        }
    }
}
    