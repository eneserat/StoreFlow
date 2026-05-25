using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreFlow.Context;

namespace StoreFlow.ViewComponent
{
    public class _SalesDataDashboardComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly StoreContext _context;
        public _SalesDataDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var orders = _context.Orders.OrderByDescending(o => o.OrderId).Include(x => x.Customer).Include(y => y.Product).Take(10).ToList();
            return View(orders);
        }
    }
}