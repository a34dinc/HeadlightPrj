using HeadlightPrj.Data.Models;
using HeadlightPrj.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HeadlightPrj.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository repository = new CategoryRepository();
        public IActionResult Index()
        {
            
            return View(repository.TListele());
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if(!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            repository.TAdd(p);
            return RedirectToAction("Index");
        }


        public IActionResult CategoryGet(int id) 
        {
            var x = repository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                Status = x.Status,
                CategoryId = x.CategoryId,
            };
            return View(ct);
        }

        [HttpPost]
        public IActionResult CategoryUpdate(Category p)
        {
            var x= repository.TGet(p.CategoryId);
            x.CategoryName = p.CategoryName;
            x.CategoryDescription = p.CategoryDescription;
            x.Status = true;
            repository.TUpdate(x);
            return RedirectToAction("Index");
        }

        public IActionResult CategoryDelete(int id) 
        {
            var x = repository.TGet(id);
            x.Status = false;
            repository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
