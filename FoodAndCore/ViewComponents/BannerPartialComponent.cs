using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class BannerPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
