using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> carList = new List<Car>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                var arrTire = new List<Tire>();
                for (int i = 0; i < data.Length; i += 2)
                {
                    var year = int.Parse(data[i]);
                    var pressure = double.Parse(data[i + 1]);
                    var tire = new Tire(year, pressure);
                    arrTire.Add(tire);
                }
                tires.Add(arrTire.ToArray());
            }
            while ((input = Console.ReadLine()) != "Engines done")
            {
                var data = input.Split().ToArray();
                for (int i = 0; i < data.Length; i += 2)
                {
                    Engine engine = new Engine(int.Parse(data[i]), double.Parse(data[i + 1]));
                    engines.Add(engine);
                }
            }
            while ((input = Console.ReadLine()) != "Show special")
            {
                var data = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var make = data[0];
                var model = data[1];
                var year = int.Parse(data[2]);
                var fuelQuantity = double.Parse(data[3]);
                var fuelConsumption = double.Parse(data[4]);
                var engine = engines[int.Parse(data[5])];
                var tire = tires[int.Parse(data[6])];
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tire);
                carList.Add(car);
            }
            carList = carList.Where(car => car.Year > 2016
            && car.Engine.HorsePower > 330
            && car.Tires.Sum(x => x.Pressure) >= 9
            && car.Tires.Sum(x => x.Pressure) <= 10)
                .ToList();
            foreach (var car in carList)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
