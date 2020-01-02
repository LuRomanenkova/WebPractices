using System;

namespace task_53.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        
        public DateTime CreationDate = DateTime.Now;

        public TimeSpan LifeTime
        {
            get { return DateTime.Now.Subtract(CreationDate); }
        }
    }
}