using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseNumber)
                .ToArray();
            PrintResult(number, CountOfArray, SumOfArray);

        }
        static int ParseNumber(string x)
        {
            return int.Parse(x);
        }
        static void PrintResult(int[] array,
            Func<int[], int> count,
            Func<int[], int> sum)
        {
            Console.WriteLine(count(array));
            Console.WriteLine(sum(array));
        }
        static int SumOfArray(int[] array)
        {
            return array.Sum();
        }
        static int CountOfArray(int[] array)
        {

            return array.Length;
        }
    }
}
