using System.Collections.Generic;
using task_5.Models;

namespace task_5.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Perfume> Perfumes { get; set; }
        public IEnumerable<BrandModel> Brands { get; set; }
    }
}