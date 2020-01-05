using System;
using System.Collections.Generic;
using System.Text;

namespace task_new_63
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public ICollection<Perfume> Perfumes { get; set; }
    }
}
