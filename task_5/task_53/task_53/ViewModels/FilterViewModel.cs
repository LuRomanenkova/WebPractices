using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using task_53.Models;

namespace task_53.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Brands { get; private set; } // список брендов
        public int? SelectedBrand { get; private set; }   // выбранный бренд
        public string SelectedName { get; private set; }    // введенное имя
        public FilterViewModel(List<Brand> brands, int? brand, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            brands.Insert(0, new Brand { Name = "All", Id = 0, Country = "not"});
            Brands = new SelectList(brands, "Id", "Name", brand);
            SelectedBrand = brand;
            SelectedName = name;
        }
    }
}