using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using task_53.Models;
using task_53.ViewModels;

namespace task_53.Controllers
{
    public class PerfumeController :  Controller
    {
        PerfumeContext db;
        public PerfumeController(PerfumeContext context)
        {
            db = context;
        }
        
        [HttpGet]
        public IActionResult AddNewPerfume()
        {
            List<BrandModel> brandModels = db.Brands
                .Select(c => new BrandModel { Id = c.Id, Name = c.Name })
                .ToList();
            // добавляем на первое место
            
            List<Perfume> _perfumes = db.Perfumes.ToList();
            IndexViewModel ivm = new IndexViewModel { Brands = brandModels, Perfumes = _perfumes };
            
            return View(ivm);
        }
        [HttpPost]
        public IActionResult AddNewPerfume(string submit, string cancel, Perfume perfume)
        {
            var button = submit ?? cancel;
            if (button == "Cancel")
            {
                return RedirectToAction("AddNewPerfume");
            }
            
            if (db.Perfumes.Any(x => x.Name == perfume.Name))
            {
                return BadRequest();
            }
            
            db.Perfumes.Add(perfume);
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }
        
    }
}