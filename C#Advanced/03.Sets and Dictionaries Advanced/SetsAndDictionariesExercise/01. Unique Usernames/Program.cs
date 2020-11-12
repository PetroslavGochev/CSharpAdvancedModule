using System;
using System.Collections.Generic;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());
            HashSet<string> name = new HashSet<string>();
            for (int i = 1; i <= numberOfNames; i++)
            {
                string input = Console.ReadLine();
                name.Add(input);
            }
            Console.WriteLine(string.Join(Environment.NewLine, name));
        }
    }
}
