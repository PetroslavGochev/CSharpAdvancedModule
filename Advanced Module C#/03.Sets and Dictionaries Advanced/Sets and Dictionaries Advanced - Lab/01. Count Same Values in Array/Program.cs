using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> dict = new Dictionary<double, int>();
            double[] arrayOfNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            foreach (var item in arrayOfNumbers)
            {
                if (!dict.ContainsKey(item))
                {
                    dict.Add(item, 0);
                }
                dict[item]++;
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
