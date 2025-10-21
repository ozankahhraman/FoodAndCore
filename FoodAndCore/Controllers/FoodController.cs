using FoodAndCore.Data.Context;
using FoodAndCore.Data.Models;
using FoodAndCore.Repostories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList.Extensions;

namespace FoodAndCore.Controllers
{
    public class FoodController : Controller
    {
        Context db = new Context();
        FoodRepository foodRepository = new FoodRepository();
        public IActionResult Index(int page=1)
        {
            
            return View(foodRepository.GetList("Category").ToPagedList(page,5));
        }
        [HttpGet]
        public IActionResult AddFood()
        {
            List<SelectListItem> values = (from x in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();

            ViewBag.vls = values;
            return View();
        }
        [HttpPost]
        public IActionResult AddFood(Food food)
        {
            foodRepository.TAdd(food);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RemoveFood(int id) 
        {
            foodRepository.TRemove(new Food { FoodId = id });
            return RedirectToAction("Index");

        }

        public IActionResult GetFood(int id)
        {
            var x = foodRepository.GetT(id);
            List<SelectListItem> values = (from y in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString()
                                           }).ToList();

            ViewBag.vls = values;
            Food f = new Food() 
            {
                FoodId = x.FoodId,
                CategoryId=x.CategoryId,
                FoodName = x.FoodName,
                FoodDescription = x.FoodDescription,
                FoodPrice = x.FoodPrice,
                FoodStock = x.FoodStock,
                FoodImgUrl = x.FoodImgUrl,
            };
            return View(f);
        }
        [HttpPost]
        public IActionResult UpdateFood(Food f)
        {
            var x = foodRepository.GetT(f.FoodId);
            x.FoodName = f.FoodName;
            x.FoodDescription = f.FoodDescription;
            x.FoodPrice = f.FoodPrice;
            x.FoodImgUrl = f.FoodImgUrl;
            x.FoodStock = f.FoodStock;
            x.CategoryId = f.CategoryId;
            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
