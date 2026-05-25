using Microsoft.AspNetCore.Mvc;
using StoreFlow.Context;

namespace StoreFlow.ViewComponent
{
    public class _ToDoDashboardComponentPartial:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly StoreContext _context;
        public _ToDoDashboardComponentPartial(StoreContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var toDos = _context.ToDos.OrderByDescending(t => t.ToDoId).Take(10).ToList();
            return View(toDos);
        }

    }
}
