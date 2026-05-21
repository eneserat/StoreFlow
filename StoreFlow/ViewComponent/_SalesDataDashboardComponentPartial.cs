using Microsoft.AspNetCore.Mvc;
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
            var orders = _context.Orders.ToList();
            return View(orders);
        }
    }
}