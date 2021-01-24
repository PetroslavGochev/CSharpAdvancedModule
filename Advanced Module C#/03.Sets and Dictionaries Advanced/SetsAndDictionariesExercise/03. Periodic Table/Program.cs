using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                var input = Console.ReadLine().Split();
                for (int k = 0; k < input.Length; k++)
                {
                    set.Add(input[k]);
                }
            }
            Console.WriteLine(string.Join(" ", set));
        }
    }
}
