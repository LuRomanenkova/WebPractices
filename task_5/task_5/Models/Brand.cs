using System;

namespace task_5.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        
        public DateTime CreationDate { get; set; }
        public TimeSpan LifeTime {
            get
            {
                return DateTime.Now.Subtract(CreationDate);
            }
        }
    }
}