using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class HeadPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
