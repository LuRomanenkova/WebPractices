using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using task_53.Models;
using task_53.ViewModels;

namespace task_53.Controllers
{
    public class HomeController : Controller
    {
        PerfumeContext db;
        public HomeController(PerfumeContext context)
        {
            db = context;
        }
        public IActionResult Index(int? brandId)
        {
            // формируем список компаний для передачи в представление
            List<BrandModel> brandModels = db.Brands
                .Select(c => new BrandModel { Id = c.Id, Name = c.Name })
                .ToList();
            // добавляем на первое место
            brandModels.Insert(0, new BrandModel { Id = 0, Name = "All" });
 
            IndexViewModel ivm = new IndexViewModel { Brands = brandModels, Perfumes = db.Perfumes };
 
            // если передан id компании, фильтруем список
            if (brandId != null && brandId > 0)
                ivm.Perfumes = db.Perfumes.Where(p => p.Brand.Id == brandId);
 
            return View(ivm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}