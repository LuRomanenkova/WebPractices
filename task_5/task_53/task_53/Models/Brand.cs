using System;
using System.Collections.Generic;

namespace task_53.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        
        public List<Perfume> Perfumes { get; set; }
        public Brand()
        {
            Perfumes = new List<Perfume>();
        }
    }
}