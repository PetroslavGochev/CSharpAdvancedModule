using System;
using System.Linq;

namespace _01._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();
            int index = 0;
            Console.WriteLine(Sum(array, index));
        }

        private static int Sum(int[] array,int index)
        {
            if(index == array.Length)
            {
                return 0;
            }
            return array[index] + Sum(array, index + 1);

        }
    }
}
