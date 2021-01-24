using System;
using System.Collections.Generic;

namespace _05._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < numberOfNames; i++)
            {
                var input = Console.ReadLine();
                set.Add(input);
            }
            Console.WriteLine(string.Join(Environment.NewLine, set));
        }
    }
}
