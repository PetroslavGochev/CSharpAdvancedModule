using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pack = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int racks = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(pack);
            int sum = 0;
            int counter = 0;
            foreach (var item in clothes)
            {
                sum += item;
                if(sum > racks)
                {
                    sum = item;
                    counter++;
                }
                else if (sum == racks)
                {
                    sum = 0;
                    counter++;
                }
            }
            if (sum > 0)
            {
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
