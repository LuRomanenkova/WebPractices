using System.Collections.Generic;
using task_53.Models;

namespace task_53.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Perfume> Perfumes { get; set; }
        public IEnumerable<BrandModel> Brands { get; set; }
    }
}