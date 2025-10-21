using FoodAndCore.Repostories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class CategoryGetList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            var categoriList = categoryRepository.TList();
            return View(categoriList);
        }
    }
}
