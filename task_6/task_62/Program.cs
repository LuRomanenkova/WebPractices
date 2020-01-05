using System;
using System.Linq;

namespace task_62
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (PerfumeStoreSixContext db = new PerfumeStoreSixContext())
            {
                // получаем объекты из бд и выводим на консоль
                var brands = db.Brands.ToList();
                Console.WriteLine("Список брендов:");
                foreach (var u in brands)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Country}");
                }
            }
            Console.ReadKey();
        }
    }
}
