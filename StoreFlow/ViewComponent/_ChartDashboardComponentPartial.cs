using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponent
{
    public class _ChartDashboardComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}