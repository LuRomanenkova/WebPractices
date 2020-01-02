using System;

namespace task_53.Models
{
    public class Perfume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Volume { get; set; }
        public int Count { get; set; }
        public Brand Brand { get; set; }
        
        public DateTime CreationDate = DateTime.Now;
        
        public TimeSpan LifeTime {
            get
            {
                return DateTime.Now.Subtract(CreationDate);
            }
        }
    }
}