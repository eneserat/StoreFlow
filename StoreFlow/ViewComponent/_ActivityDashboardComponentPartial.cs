using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponent
{
    public class _ActivityDashboardComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly StoreContext _context;

        public _ActivityDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.Activities.ToList();
            return View(values);
        }
    }
}
