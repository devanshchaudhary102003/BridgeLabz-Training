using System;
using Newtonsoft.Json;

namespace JsonExample
{
    // Car class definition
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }

    class Program
    {
        static void Main()
        {
            // Creating Car object
            Car car = new Car
            {
                Brand = "Toyota",
                Model = "Fortuner",
                Year = 2024
            };

            string json = JsonConvert.SerializeObject(car, Formatting.Indented);

            Console.WriteLine(json);
        }
    }
}