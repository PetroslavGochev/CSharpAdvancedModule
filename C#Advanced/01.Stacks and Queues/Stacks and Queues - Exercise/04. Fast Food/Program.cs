using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheDay = int.Parse(Console.ReadLine());
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queryDay = new Queue<int>(input);
            int maximum = input.Max();
            for (int i = 0; i < input.Length; i++)
            {
                int quantity = queryDay.Dequeue();
                if (quantityOfTheDay < quantity)
                {
                    queryDay.Enqueue(quantity);
                }
                else
                {
                    quantityOfTheDay -= quantity;
                }
            }
            Console.WriteLine(maximum);
            if (queryDay.Count == 0)
            {
                Console.WriteLine($"Orders complete");
            }
            else
            {
                StringBuilder result = new StringBuilder();
                foreach (var item in queryDay)
                {
                    result.Append($"{item} ");
                }
                Console.WriteLine($"Orders left: {result.ToString().Trim()}");
            }
        }
    }
}
