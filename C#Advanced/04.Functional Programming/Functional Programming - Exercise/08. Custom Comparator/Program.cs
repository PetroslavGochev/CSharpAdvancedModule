    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _08._Custom_Comparator
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Array.Sort(numbers, (x, y) =>
                    x % 2 == 0 && y % 2 != 0 ? -1 :
                    x % 2 != 0 && y % 2 == 0 ? 1 :
                    x.CompareTo(y));
                Console.WriteLine(string.Join(" ",numbers));
            }
        }
    }
