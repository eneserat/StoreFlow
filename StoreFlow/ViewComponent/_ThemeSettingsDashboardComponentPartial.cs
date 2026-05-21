using Microsoft.AspNetCore.Mvc;

namespace StoreFlow.ViewComponent
{
    public class _ThemeSettingsDashboardComponentPartial:Microsoft.AspNetCore.Mvc.ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
