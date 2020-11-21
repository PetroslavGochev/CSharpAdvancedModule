using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<Engine> listEngine = new List<Engine>();
            List<Car> listOfCar = new List<Car>();
            for (int i = 1; i <= number; i++)
            {
                var input = Console.ReadLine()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();
                var model = input[0];
                var power = int.Parse(input[1]);
                var displacement = 0;
                var eff = "n/a";
                if (input.Length == 4)
                {
                    displacement = int.Parse(input[2]);
                    eff = input[3];
                }
                else if(input.Length == 3)
                {
                    if (char.IsLetter(char.Parse(input[2][0].ToString())))
                    {
                        eff = input[2];                     
                    }
                    else
                    {
                        displacement = int.Parse(input[2]);
                    }
                }
                Engine engine = new Engine(model, power, displacement, eff);
                listEngine.Add(engine);
            }
            number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var engineModel = input[1];
                var weight = 0;
                var color = "n/a";
                if (input.Length == 4)
                {
                    weight = int.Parse(input[2]);
                    color = input[3];
                }
                else if (input.Length == 3)
                {
                    if (char.IsLetter(char.Parse(input[2][0].ToString())))
                    {
                        color = input[2];                       
                    }
                    else
                    {
                        weight = int.Parse(input[2]);
                    }
                }
                var engine = listEngine.Where(x => x.Model == engineModel).FirstOrDefault();
                Car car = new Car(model, engine, weight, color);
                listOfCar.Add(car);
            }
            listOfCar
                 .ForEach(x => Console.WriteLine(x));
        }
    }
}
