using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 1; i <= number; i++)
            {
                var integer = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(integer))
                {
                    numbers.Add(integer, 0);
                }
                numbers[integer]++;
            }
            foreach (var item in numbers)
            {
                if(item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    return;
                }
            }
        }
    }
}
