using HeadlightPrj.Data.Models;
using HeadlightPrj.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace HeadlightPrj.Controllers
{
    public class HeadLightController : Controller
    {
        Context c = new Context();
        HeadLightRepository repository = new HeadLightRepository();
        public IActionResult Index(int page=1)
        {
            
            return View(repository.TListele("Category").ToPagedList(page,3));
        }

        [HttpGet]
        public IActionResult HeadLightAdd()
        {
            List<SelectListItem> list = (from x in c.Categories
                                         select new SelectListItem
                                         {
                                             Value = x.CategoryId.ToString(),
                                             Text = x.CategoryName
                                             
                                         }).ToList();

            ViewBag.v1= list;
            return View();
        }

        [HttpPost]
        public IActionResult HeadLightAdd(HeadLight p) 
        {

            HeadLight headLight = new HeadLight();
            headLight.Name = p.Name;
            headLight.Description = p.Description;
            headLight.Stock=p.Stock;
            headLight.Price = p.Price;
            headLight.ImageURL = p.ImageURL;
            headLight.CategoryId = p.CategoryId;
            repository.TAdd(headLight);
            return RedirectToAction("Index");
        }

        public IActionResult HeadLightDelete(int id)
        {
            //HeadLight headLight =new HeadLight();
            //headLight.HeadLightId = id;
            repository.TDelete(new HeadLight { HeadLightId =id});
            return RedirectToAction("Index");
        }

        public IActionResult HeadLightGet(int id)
        {
            List<SelectListItem> listt = (from c in c.Categories
                                      select new SelectListItem
                                      {
                                          Value =c.CategoryId.ToString(),
                                          Text = c.CategoryName
                                      }).ToList();

            var x = repository.TGet(id);
            ViewBag.v1= listt;
            HeadLight head = new HeadLight()
            {
                HeadLightId = id,
                Name = x.Name,
                Description = x.Description,
                Stock = x.Stock,
                Price = x.Price,
                ImageURL = x.ImageURL,
                CategoryId = x.CategoryId
            };
            return View(head);
        }

        [HttpPost]
        public IActionResult HeadLightUpdate(HeadLight p)
        {
            var x = repository.TGet(p.HeadLightId);

            x.CategoryId = p.CategoryId;
            x.Name = p.Name;
            x.Description = p.Description;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            repository.TUpdate(x);
            return RedirectToAction("Index");
        }
    }
}
