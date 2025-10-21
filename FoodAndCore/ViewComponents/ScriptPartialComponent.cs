using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class ScriptPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
