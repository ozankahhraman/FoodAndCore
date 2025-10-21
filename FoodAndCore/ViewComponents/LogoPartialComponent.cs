using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class LogoPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
