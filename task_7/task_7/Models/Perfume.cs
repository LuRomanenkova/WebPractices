using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_7.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }
        public int Count { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
