using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            for (int i = 1; i <= input.Sum(); i++)
            {
                int number = int.Parse(Console.ReadLine());
                if(i <= input[0])
                {
                    first.Add(number);
                }
                else
                {
                    second.Add(number);
                }
            }
            foreach (var item in first)
            {
                if (second.Contains(item))
                {
                    Console.Write($"{item} ");
                }
            }
        }
    }
}
