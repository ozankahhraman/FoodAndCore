using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class BannerBottomPartialComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
