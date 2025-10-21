using FoodAndCore.Data.Models;
using FoodAndCore.Repostories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace FoodAndCore.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        //[Authorize]
        public IActionResult Index(int page=1)
        {
            return View(categoryRepository.TList().ToPagedList(page,5));
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category ct)
        {
            categoryRepository.TAdd(ct);
            return RedirectToAction("Index");
        }
        public IActionResult GetCategory(int id)
        {
            var x = categoryRepository.GetT(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID = x.CategoryID,
            };
            return View(ct);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category ct)
        {
            var x = categoryRepository.GetT(ct.CategoryID);
            x.CategoryName = ct.CategoryName;
            x.CategoryDescription = ct.CategoryDescription;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveCategory(int id)
        {
            var x = categoryRepository.GetT(id);
            if (x.Status == false)
            {
                x.Status=true;
            }
            else
            {
                x.Status = false;
            }
                categoryRepository.TUpdate(x);
            return RedirectToAction("Index");
        }


    }

    
}
