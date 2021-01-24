using System;
using System.Collections;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Queue<string> name = new Queue<string>();
            while((input = Console.ReadLine()) != "End")
            {
                if(input == "Paid")
                {
                    while (name.Count > 0)
                    {
                        Console.WriteLine(name.Dequeue());
                    }
                    continue;
                }
                name.Enqueue(input);
            }
            Console.WriteLine($"{name.Count} people remaining.");
        }
    }
}
