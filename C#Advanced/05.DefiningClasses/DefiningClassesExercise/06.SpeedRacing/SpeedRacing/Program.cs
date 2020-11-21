using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfcars = int.Parse(Console.ReadLine());
            string input = string.Empty;
            List<Car> carList = new List<Car>();
            for (int i = 0; i < numberOfcars; i++)
            {
                input = Console.ReadLine();
                var data = input
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();
                var model = data[0];
                var fuelAmount = double.Parse(data[1]);
                var fuelConsumpt = double.Parse(data[2]);
                Car car = new Car(model, fuelAmount, fuelConsumpt);
                carList.Add(car);
            }
            while((input = Console.ReadLine()) != "End")
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = data[1];
                double distance = double.Parse(data[2]);
                carList.Where(x => x.Model == model).ToList().ForEach(x => x.Travel(distance));
            }
            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }
        }
    }
}
