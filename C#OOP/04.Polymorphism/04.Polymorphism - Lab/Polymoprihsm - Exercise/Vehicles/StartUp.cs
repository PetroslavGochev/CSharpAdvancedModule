using System;
using System.Linq;
using Vehicles.Models;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] truckData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
            Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));
            int numberOfCommand = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfCommand; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];
                var type = input[1];
                var distance = double.Parse(input[2]);
                if(command == "Drive")
                {
                    if(type == "Car")
                    {
                        car.Driving(distance);
                    }
                    else
                    {
                        truck.Driving(distance);
                    }
                }
                else
                {
                    if(type == "Car")
                    {
                        car.Refueling(distance);
                    }
                    else
                    {
                        truck.Refueling(distance);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);

        }
    }
}
