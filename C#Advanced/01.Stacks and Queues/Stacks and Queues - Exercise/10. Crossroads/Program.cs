using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();
            int green = int.Parse(Console.ReadLine());
            int pass = int.Parse(Console.ReadLine());
            int count = 0;
            string input = string.Empty;
            while((input = Console.ReadLine()) != "END")
            {
                if(input == "green")
                {
                    int passed = green;
                   while (cars.Count > 0)
                    {
                        var car = cars.Peek();
                        int time = pass + passed;
                        if(car.Length <= time)
                        {
                            passed -= car.Length;
                            cars.Dequeue();
                            count++;
                            if(passed <= 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            var crash = car.Substring(time,car.Length-time); 
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{car} was hit at {crash[0]}.");
                            return;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"Everyone is safe.");
            Console.WriteLine($"{count} total cars passed the crossroads.");

        }
    }
}
