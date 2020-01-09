using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_7.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
        public Brand()
        {
            Perfumes = new List<Perfume>();
        }
    }
}
