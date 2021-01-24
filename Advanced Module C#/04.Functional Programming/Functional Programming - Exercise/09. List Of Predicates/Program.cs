using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var result = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                bool flag = true;
                Predicate<int> isDivider = x => i % x == 0;
                foreach (var num in dividers)
                {
                    if (!isDivider(num))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
