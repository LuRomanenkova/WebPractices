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
    [ApiController]
    [Route("api/[controller]")]
    public class BrandsController : ControllerBase
    {
        PerfumeStoreContext db;
        public BrandsController(PerfumeStoreContext context)
        {
            db = context;

            if (db.Brands.Count() == 0)
            {
                Brand Chanel = new Brand { Name = "Chanel", Country = "France" };
                Brand Armani = new Brand { Name = "Armani", Country = "Italy" };
                Brand Versace = new Brand { Name = "Versace", Country = "Italy" };
                Brand Givenchy = new Brand { Name = "Givenchy", Country = "France" };
                Brand Burberry = new Brand { Name = "Burberry", Country = "UK" };
                Brand Kenzo = new Brand { Name = "Kenzo", Country = "France" };
                Brand Lanvin = new Brand { Name = "Lanvin", Country = "France" };

                if (!context.Brands.Any())
                {
                    context.Brands.AddRange(Chanel, Armani, Versace, Givenchy, Burberry, Kenzo, Lanvin);
                    context.SaveChanges();
                }

                if (!context.Perfumes.Any())
                {
                    context.Perfumes.AddRange(
                        new Perfume
                        {
                            Name = "Coco Mademoiselle",
                            Price = 6000,
                            Count = 10,
                            Volume = 30,
                            Brand = Chanel
                        },
                        new Perfume
                        {
                            Name = "Eclat d’Arpege",
                            Price = 1500,
                            Count = 50,
                            Volume = 50,
                            Brand = Lanvin
                        },
                        new Perfume
                        {
                            Name = "Acqua di Gioia",
                            Price = 4700,
                            Count = 15,
                            Volume = 50,
                            Brand = Armani
                        },
                        new Perfume
                        {
                            Name = "Bright Crystal",
                            Price = 4000,
                            Count = 10,
                            Volume = 50,
                            Brand = Versace
                        },
                        new Perfume
                        {
                            Name = "Very Irresistible",
                            Price = 4500,
                            Count = 15,
                            Volume = 50,
                            Brand = Givenchy
                        },
                        new Perfume
                        {
                            Name = "Chance Eau Tendre",
                            Price = 7400,
                            Count = 15,
                            Volume = 50,
                            Brand = Chanel
                        },
                        new Perfume
                        {
                            Name = "Body Tender",
                            Price = 2500,
                            Count = 15,
                            Volume = 60,
                            Brand = Burberry
                        },
                        new Perfume
                        {
                            Name = "L'eau par",
                            Price = 2400,
                            Count = 15,
                            Volume = 50,
                            Brand = Kenzo
                        }
                    );
                    context.SaveChanges();
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> Get()
        {
            return await db.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> Get(int id)
        {
            Brand user = await db.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> Post([FromForm] Brand brand)
        {
            if (brand == null || db.Brands.Any(x => x.Name == brand.Name))
            {
                return BadRequest();
            }

            db.Brands.Add(brand);
            await db.SaveChangesAsync();
            return Ok(brand);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> Put(int id, [FromForm] Brand brand)
        {
            Brand brandTemplate = db.Brands.FirstOrDefault(x => x.Id == id);
            if (brandTemplate == null)
            {
                return NotFound();
            }
            brandTemplate.Name = brand.Name == null ? brandTemplate.Name : brand.Name;
            brandTemplate.Country = brand.Country == null ? brandTemplate.Country : brand.Country;

            db.Update(brandTemplate);
            await db.SaveChangesAsync();
            return Ok(brandTemplate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> Delete(int id)
        {
            Brand brand = db.Brands.FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            db.Brands.Remove(brand);
            await db.SaveChangesAsync();
            return Ok(brand);
        }
    }
}
