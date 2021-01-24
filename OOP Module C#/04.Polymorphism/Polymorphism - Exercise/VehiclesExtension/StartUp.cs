using System;
using System.Linq;
using VehiclesExtension.Models;

namespace VehiclesExtension
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
            string[] busData = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();
            Vehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]),double.Parse(carData[3]));
            Vehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]),double.Parse(truckData[3]));
            Vehicle bus = new Bus(double.Parse(busData[1]), double.Parse(busData[2]),double.Parse(busData[3]));
            int numberOfCommand = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfCommand; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = input[0];
                var type = input[1];
                var distance = double.Parse(input[2]);
                if (command == "Drive")
                {
                    if (type == "Car")
                    {
                        car.Driving(distance);
                    }
                    else if (type == "Truck")
                    {
                        truck.Driving(distance);
                    }
                    else if(type == "Bus")
                    {
                        bus.Driving(distance);
                    }
                }
                else if (command == "Refuel")
                {
                    if (type == "Car")
                    {
                        car.Refueling(distance);
                    }
                    else if (type == "Truck")
                    {
                        truck.Refueling(distance);
                    }
                    else if (type == "Bus")
                    {
                        bus.Refueling(distance);
                    }
                }
                else if(command == "DriveEmpty")
                {
                    if(type == "Bus")
                    {
                        ((Bus)bus).EmptyBus(distance);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
