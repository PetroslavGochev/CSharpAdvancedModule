using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int startNumber = input[0];
            int endNumber = input[1];
            string evenOrOdd = Console.ReadLine();
            Predicate<int> result = evenOrOdd == "even" ? new Predicate<int>(x => x % 2 == 0) : new Predicate<int>(x => x % 2 != 0);
            Action<List<int>> printResult = list => Console.WriteLine(string.Join(" ", list));
            List<int> numbers = new List<int>();
            for (int i = startNumber; i <= endNumber; i++)
            {
                if (result(i))
                {
                    numbers.Add(i);
                }
            }
            printResult(numbers);          
        }
    }
}
