using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class HeaderPartialComponent : ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
