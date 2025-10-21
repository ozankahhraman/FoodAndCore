using FoodAndCore.Repostories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class FooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categories = categoryRepository.TList();
            return View(categories);
        }
    }
}
