using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseNumber)
                .Where(EvenNumber)
                .OrderBy(x=>x)
                .ToArray();
            Console.WriteLine(string.Join(", ", numbers));
        }
        static int ParseNumber (string x)
        {
            return int.Parse(x);
        }
        static bool EvenNumber(int x)
        {
            return x % 2 == 0;
        }
    }
}
