using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
       
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();
            int numberOfCars = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfCars; i++)
            {
                var data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = data[0];
                Engine engine = new Engine(int.Parse(data[1]), int.Parse(data[2]));
                Cargo cargo = new Cargo(int.Parse(data[3]), data[4]);
               Tires[] tire = new Tires[]
                {
                    new Tires(int.Parse(data[6]),double.Parse(data[5])),
                    new Tires(int.Parse(data[8]),double.Parse(data[7])),
                    new Tires(int.Parse(data[10]),double.Parse(data[9])),
                    new Tires(int.Parse(data[12]),double.Parse(data[11]))
                };
                Car car = new Car(engine, cargo, model, tire);
                carList.Add(car);
            }
            string input = Console.ReadLine();
            if(input == "fragile")
            {
                carList
                    .Where(x => x.Tire.Any(t => t.Pressure < 1))
                    .Where(x=>x.Cargo.Type == "fragile")
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
            else if(input == "flamable")
            {
                carList
                    .Where(x => x.Engine.Power > 250)
                    .Where(x => x.Cargo.Type == "flamable")
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
