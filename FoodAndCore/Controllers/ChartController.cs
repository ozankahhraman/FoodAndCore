using FoodAndCore.Data;
using FoodAndCore.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace FoodAndCore.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                ProName = "Computer",
                Stock = 150
            });
            cs.Add(new Class1()
            {
                ProName = "Lcd",
                Stock = 75
            });
            cs.Add(new Class1()
            {
                ProName = "Usb Disk",
                Stock = 220
            });
            return cs;
        }

        public IActionResult Statistics()
        {
            Context db = new Context();
            var food_count = db.Foods.Count();
            var category_count = db.Categories.Count();
            var fruit_count = db.Foods.Where(x=> x.CategoryId == db.Categories.Where(z=> z.CategoryName== "Fruit").Select(y=> y.CategoryID).FirstOrDefault()).Count();
            var vegatables_count = db.Foods.Where(x=> x.CategoryId == db.Categories.Where(z => z.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            var legumes_count = db.Foods.Where(x => x.CategoryId == db.Categories.Where(z => z.CategoryName == "Legumes").Select(y => y.CategoryID).FirstOrDefault()).Count();
            var sum_food = db.Foods.Sum(x=> x.FoodStock);
            var max_food = db.Foods.OrderByDescending(x=> x.FoodStock).Select(y=> y.FoodName).FirstOrDefault();
            var max_price = db.Foods.Average(x => x.FoodPrice).ToString("0.00");
            ViewBag.fc = food_count;
            ViewBag.cc = category_count;
            ViewBag.frc = fruit_count;
            ViewBag.vc = vegatables_count;
            ViewBag.lc = legumes_count;
            ViewBag.sf = sum_food;
            ViewBag.mf = max_food;
            ViewBag.mp = max_price;
            return View();
        }
    }
}
