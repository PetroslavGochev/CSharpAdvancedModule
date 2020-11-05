using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            Queue<string> names = new Queue<string>(input);
            int n = int.Parse(Console.ReadLine());
            int counter = n;
            while(names.Count > 1)
            {
                counter--;
                if (counter == 0)
                {
                  Console.WriteLine($"Removed {names.Dequeue()}");
                    counter = n;
                    continue;
                }
                names.Enqueue(names.Dequeue());
                
            }
            Console.WriteLine($"Last is {names.Dequeue()}");
        }
    }
}
