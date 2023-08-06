using HeadlightPrj.Data;
using HeadlightPrj.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeadlightPrj.Controllers
{
    
    public class ChartController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public IActionResult VisualizeProductResult2() 
        {
            return Json(ProList2());
        }

        private List<Class1> ProList2()
        {
            List<Class1> cs2 = new List<Class1>();
            using(var c = new Context())
            {
                cs2 = c.HeadLights.Select(x => new Class1
                {
                    ProName = x.Name,
                    Stock = x.Stock

                }).ToList();
            }

            return cs2; 
        }

        private List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                ProName = "Far",
                Stock = 75
            });
            cs.Add(new Class1()
            {
                ProName = "Far2",
                Stock = 120
            });
            cs.Add(new Class1()
            {
                ProName = "Far3",
                Stock = 200
            });

            return cs;
        }

        public IActionResult Statistics()
        {
            // Toplam Ürün Sayısı
            var deger1 = c.HeadLights.Count();
            ViewBag.v1 = deger1;

            // Toplam Kategori Sayısı
            var deger2 = c.Categories.Count();
            ViewBag.v2 = deger2;

            // Toplam Far Çeşit Sayısı
            var hoid = c.Categories.Where(x => x.CategoryName == "Far").Select(y => y.CategoryId).FirstOrDefault();
            var deger3 = c.HeadLights.Where(x => x.CategoryId == hoid).Count();
            ViewBag.v3 = deger3;

            // Toplam Far Camı Çeşit Sayısı
            var hoid2 = c.Categories.Where(x => x.CategoryName == "Far Camı").Select(y => y.CategoryId).FirstOrDefault();
            var deger4 = c.HeadLights.Where(x=>x.CategoryId == hoid2).Count();
            ViewBag.v4 = deger4;

            // Toplam Far Beyni Çeşit Sayısı
            var hoid3 = c.Categories.Where(x => x.CategoryName == "Far Beyni").Select(y => y.CategoryId).FirstOrDefault();
            var deger5 = c.HeadLights.Where(x=>x.CategoryId == hoid3).Count();
            ViewBag.v5 = deger5;

            // Far ürünlerinin Toplam Stok Durumu 
            var hoid4 = c.Categories.Where(x => x.CategoryName == "Far").Select(y => y.CategoryId).FirstOrDefault();
            var deger6 = c.HeadLights.Where(y=>y.CategoryId == hoid4).Sum(x => x.Stock);
            ViewBag.v6 = deger6;

            // Far Camı ürünlerinin Toplam Stok Durumu 
            var hoid5 = c.Categories.Where(x => x.CategoryName == "Far Camı").Select(y => y.CategoryId).FirstOrDefault();
            var deger7 = c.HeadLights.Where(y => y.CategoryId == hoid5).Sum(x => x.Stock);
            ViewBag.v7 = deger7;

            // Far Camı ürünlerinin Toplam Stok Durumu 
            var hoid6 = c.Categories.Where(x => x.CategoryName == "Far Beyni").Select(y => y.CategoryId).FirstOrDefault();
            var deger8 = c.HeadLights.Where(y => y.CategoryId == hoid5).Sum(x => x.Stock);
            ViewBag.v8 = deger8;

            // En çok stoğa sahip ürün
            var deger9 = c.HeadLights.OrderByDescending(x=>x.Stock).Select(y=>y.Name).FirstOrDefault();
            ViewBag.v9 = deger9;

            // En az stoğa sahip ürün
            var deger10 = c.HeadLights.OrderBy(x => x.Stock).Select(y => y.Name).FirstOrDefault();
            ViewBag.v10 = deger10;

            // Far ortalama ücret
            var hoid7 = c.Categories.Where(x=>x.CategoryName == "Far").Select(y=>y.CategoryId).FirstOrDefault();
            var deger11 = c.HeadLights.Where(x => x.CategoryId == hoid7).Average(t => t.Price);
            ViewBag.v11 = deger11;

            // Far Camı ortalama ücret
            var hoid8 = c.Categories.Where(x => x.CategoryName == "Far Camı").Select(y => y.CategoryId).FirstOrDefault();
            var deger12 = c.HeadLights.Where(x => x.CategoryId == hoid8).Average(t => t.Price);
            ViewBag.v12 = deger12;

            // Far Beyni ortalama ücret
            var hoid9 = c.Categories.Where(x => x.CategoryName == "Far Beyni").Select(y => y.CategoryId).FirstOrDefault();
            var deger13 = c.HeadLights.Where(x => x.CategoryId == hoid9).Average(t => t.Price);
            ViewBag.v13 = deger13;

            // En pahalı Far Ürünü
            var hoid10 = c.Categories.Where(y => y.CategoryName == "Far").Select(y => y.CategoryId).FirstOrDefault();
            var deger14 = c.HeadLights.Where(x => x.CategoryId == hoid10).Max(y => y.Price);
            ViewBag.v14 = deger14;

            // En pahalı Far Camı Ürünü
            var hoid11 = c.Categories.Where(y => y.CategoryName == "Far Camı").Select(y => y.CategoryId).FirstOrDefault();
            var deger15 = c.HeadLights.Where(x=>x.CategoryId == hoid11).Max(y => y.Price);
            ViewBag.v15 = deger15;

            // En pahalı Far Beyni Ürünü
            var hoid12 = c.Categories.Where(y => y.CategoryName == "Far Beyni").Select(y => y.CategoryId).FirstOrDefault();
            var deger16 = c.HeadLights.Where(x => x.CategoryId == hoid12).Max(y => y.Price);
            ViewBag.v16 = deger16;


            return View();
        }


    }
}
