using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string input = string.Empty;
            Queue<string> cars = new Queue<string>();
            int pass = 0;
            while((input = Console.ReadLine()) != "end")
            {
                if(input == "green")
                {
                    
                    for (int i = 0; i < number; i++)
                    {
                        if(cars.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        pass++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }
            Console.WriteLine($"{pass} cars passed the crossroads.");
        }
    }
}
