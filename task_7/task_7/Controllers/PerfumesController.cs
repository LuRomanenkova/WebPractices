using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_7.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task_7.Controllers
{
    [Route("api/[controller]")]
    public class PerfumesController : Controller
    {
        PerfumeStoreContext db;
        public PerfumesController(PerfumeStoreContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfume>>> Get()
        {
            return await db.Perfumes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Perfume>> Get(int id)
        {
            Perfume perfume = await db.Perfumes.FirstOrDefaultAsync(x => x.Id == id);
            if (perfume == null)
                return NotFound();
            return new ObjectResult(perfume);
        }

        [HttpPost]
        public async Task<ActionResult<Perfume>> Post([FromForm] Perfume perfume)
        {
            if (perfume == null || db.Perfumes.Any(x => x.Name == perfume.Name) || !db.Brands.Any(x => x.Id == perfume.BrandId))
            {
                return BadRequest();
            }

            db.Perfumes.Add(perfume);
            await db.SaveChangesAsync();
            return Ok(perfume);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Perfume>> Put(int id, [FromForm] Perfume perfume)
        {
            Perfume perfumeTemplate = db.Perfumes.FirstOrDefault(x => x.Id == id);
            if (perfumeTemplate == null)
            {
                return NotFound();
            }
            perfumeTemplate.Name = perfume.Name == null ? perfumeTemplate.Name : perfume.Name;
            perfumeTemplate.Volume = perfume.Volume <= 0 ? perfumeTemplate.Volume : perfume.Volume;
            perfumeTemplate.Price = perfume.Price <= 0 ? perfumeTemplate.Price : perfume.Price;
            perfumeTemplate.Count = perfume.Count <= 0 ? perfumeTemplate.Count : perfume.Count;

            db.Update(perfumeTemplate);
            await db.SaveChangesAsync();
            return Ok(perfumeTemplate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Perfume>> Delete(int id)
        {
            Perfume perfume = db.Perfumes.FirstOrDefault(x => x.Id == id);
            if (perfume == null)
            {
                return NotFound();
            }
            db.Perfumes.Remove(perfume);
            await db.SaveChangesAsync();
            return Ok(perfume);
        }
    }
}
