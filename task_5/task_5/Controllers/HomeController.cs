using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using task_5.Models;
using task_5.ViewModels;

namespace task_5.Controllers
{
    public class HomeController : Controller
    {
        List<Perfume> _perfumes;
        List<Brand> _brands;
        public HomeController()
        {
            Brand Chanel = new Brand { Id = 1, Name = "Chanel", Country = "France" };
            Brand Armani = new Brand { Id = 2, Name = "Armani", Country = "Italy" };
            Brand Versace = new Brand { Id = 3, Name = "Versace", Country = "Italy" };
            Brand Givenchy = new Brand { Id = 4, Name = "Givenchy", Country = "France" };
            Brand Burberry = new Brand { Id = 5, Name = "Burberry", Country = "UK" };
            Brand Kenzo = new Brand { Id = 6, Name = "Kenzo", Country = "France" };
            Brand Lanvin = new Brand { Id = 7, Name = "Lanvin", Country = "France" };
            _brands = new List<Brand> { Chanel, Armani, Versace, Givenchy, Burberry, Kenzo, Lanvin };
 
            _perfumes = new List<Perfume>
            {
                new Perfume { Id = 1, Name = "Coco Mademoiselle", Price = 6000, Volume = 50 , Count = 50, Brand = Chanel },
                new Perfume { Id = 2, Name = "Eclat d’Arpege", Price = 1500, Volume = 30, Count = 10, Brand = Lanvin },
                new Perfume { Id = 3, Name = "Acqua di Gioia", Price = 4700, Volume = 50, Count = 15, Brand = Armani },
                new Perfume { Id = 4, Name = "Bright Crystal", Price = 4000, Volume = 50, Count = 10, Brand = Versace },
                new Perfume { Id = 5, Name = "Very Irresistible", Price = 4500, Volume = 50, Count = 15, Brand = Givenchy },
                new Perfume { Id = 6, Name = "Chance Eau Tendre", Price = 7400, Volume = 50, Count = 15, Brand = Chanel },
                new Perfume { Id = 7, Name = "Body Tender", Price = 2500, Volume = 60, Count = 15, Brand = Burberry },
                new Perfume { Id = 8, Name = "L'eau par", Price = 2400, Volume = 50, Count = 15, Brand = Kenzo }
            };
        }
        public IActionResult Index(int? brandId)
        {
            // формируем список компаний для передачи в представление
            List<BrandModel> brandModels = _brands
                .Select(c => new BrandModel { Id = c.Id, Name = c.Name })
                .ToList();
            // добавляем на первое место
            brandModels.Insert(0, new BrandModel { Id = 0, Name = "All" });
 
            IndexViewModel ivm = new IndexViewModel { Brands = brandModels, Perfumes = _perfumes };
 
            // если передан id компании, фильтруем список
            if (brandId != null && brandId > 0)
                ivm.Perfumes = _perfumes.Where(p => p.Brand.Id == brandId);
 
            return View(ivm);
        }
    }
}