using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;
using StoreFlow.Entities;

namespace StoreFlow.ViewComponent.StatisticsViewComponents
{

    public class _StatisticsWidgetComponentPartial:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly StoreContext _context;

        public _StatisticsWidgetComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.categoryCount = _context.Categories.Count();
            ViewBag.productMaxPrice = _context.Products.Max(p => p.ProductPrice);
            ViewBag.productMinPrice = _context.Products.Min(p => p.ProductPrice);
            ViewBag.ProducMaxPriceProductName = _context.Products.Where(p => p.ProductPrice == _context.Products.Max(p => p.ProductPrice)).Select(p => p.ProductName).FirstOrDefault();
            ViewBag.productMinPriceProductName = _context.Products.Where(p => p.ProductPrice == _context.Products.Min(p => p.ProductPrice)).Select(p => p.ProductName).FirstOrDefault();
            ViewBag.TotalSumProductStock = _context.Products.Sum(p => p.ProductStock);
            ViewBag.avgProductStock = _context.Products.Average(p => p.ProductStock);
            ViewBag.LowStockProducts = _context.Products.Where(p => p.ProductStock < 10).ToList();  
            ViewBag.TotalStockValue=_context.Products.Sum(p => p.ProductPrice * p.ProductStock);
            var totalStock = _context.Products.Sum(p => p.ProductStock);
            var avgStock = _context.Products.Any()
                ? _context.Products.Average(p => p.ProductStock)
                : 0;

            ViewBag.StockTrend = totalStock - (avgStock * _context.Products.Count());

            var last7Days = DateTime.Now.AddDays(-7);

            var stockTrend = _context.ProductStockHistories
                .Where(x => x.Date >= last7Days)
                .GroupBy(x => x.Date.Date)
                .Select(x => new
                {
                    date = x.Key,
                    totalStock = x.Sum(s => s.ProductStock)
                })
                .OrderBy(x => x.date)
                .ToList();

            ViewBag.StockTrend7Days = stockTrend;


            return View();
        }

    }

}
