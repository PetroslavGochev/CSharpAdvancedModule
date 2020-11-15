    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace _03._Custom_Min_Function
    {
        class Program
        {
            static void Main(string[] args)
            {
                Func<int[], int> printNumber = p => p.Min();
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Console.WriteLine(printNumber(numbers));
            }
        }
    }
