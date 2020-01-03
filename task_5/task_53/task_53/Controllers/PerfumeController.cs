using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<Brand> brandModels = db.Brands
//                .Select(c => new BrandModel { Id = c.Id, Name = c.Name })
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

//            var i = db.Brands.Find(perfume.Brand.Id);
//            perfume.Brand = i;
            //System.Diagnostics.Debug.WriteLine(perfume);
            db.Perfumes.Add(perfume);
            db.SaveChanges();
            return Redirect("~/Home/Index");
        }
        
         public async Task<IActionResult> Index(int? brand, string name, int page = 1, 
             SortState sortOrder = SortState.NameAsc)
         {
            int pageSize = 3;
 
            //фильтрация
            IQueryable<Perfume> perfumes = db.Perfumes.Include(x=>x.Brand);
 
            if (brand != null && brand != 0)
            {
                perfumes = perfumes.Where(p => p.BrandId == brand);
            }
            if (!String.IsNullOrEmpty(name))
            {
                perfumes = perfumes.Where(p => p.Name.Contains(name));
            }
 
            // сортировка
            switch (sortOrder)
            {
                case SortState.NameDesc:
                    perfumes = perfumes.OrderByDescending(s => s.Name);
                    break;
                case SortState.PriceAsc:
                    perfumes = perfumes.OrderBy(s => s.Price);
                    break;
                case SortState.PriceDesc:
                    perfumes = perfumes.OrderByDescending(s => s.Price);
                    break;
                case SortState.BrandAsc:
                    perfumes = perfumes.OrderBy(s => s.Brand.Name);
                    break;
                case SortState.BrandDesc:
                    perfumes = perfumes.OrderByDescending(s => s.Brand.Name);
                    break;
                default:
                    perfumes = perfumes.OrderBy(s => s.Name);
                    break;
            }
 
            // пагинация
            var count = await perfumes.CountAsync();
            var items = await perfumes.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Brands.ToList(), brand, name),
                Perfumes = items
            };
            return View(viewModel);
         }
        
    }
}