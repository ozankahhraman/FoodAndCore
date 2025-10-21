using FoodAndCore.Repostories;
using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.ViewComponents
{
    public class FoodGetList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            FoodRepository foodRepository = new FoodRepository();
            var foods = foodRepository.TList();
            return View(foods);
        }

    }
}
