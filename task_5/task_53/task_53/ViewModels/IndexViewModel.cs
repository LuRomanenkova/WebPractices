using System.Collections.Generic;
using task_53.Models;

namespace task_53.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Perfume> Perfumes { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}