using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int divisible = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = x => x % divisible == 0;
            Func<List<int>, List<int>> reverse = result =>
            { 
                result.Reverse();
                return result;
            };
            foreach (var number in reverse(numbers))
            {
                if (!isDivisible(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
