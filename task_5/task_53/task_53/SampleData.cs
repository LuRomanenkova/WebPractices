using System;
using System.Collections.Generic;
using task_53.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace task_53
{
    public class SampleData
    {
        public static void Initialize(PerfumeContext context)
        {
            Brand Chanel = new Brand { Id = 1, Name = "Chanel", Country = "France"};
            Brand Armani = new Brand { Id = 2, Name = "Armani", Country = "Italy" };
            Brand Versace = new Brand { Id = 3, Name = "Versace", Country = "Italy" };
            Brand Givenchy = new Brand { Id = 4, Name = "Givenchy", Country = "France" };
            Brand Burberry = new Brand { Id = 5, Name = "Burberry", Country = "UK" };
            Brand Kenzo = new Brand { Id = 6, Name = "Kenzo", Country = "France" };
            Brand Lanvin = new Brand { Id = 7, Name = "Lanvin", Country = "France" };
            
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
                        Price = 1500,
                        Count = 10,
                        Volume = 30,
                        Brand = Chanel
                    },
                    new Perfume
                    {
                        Name = "Eclat d’Arpege",
                        Price = 6000,
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
                        Brand = Burberry,
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
}