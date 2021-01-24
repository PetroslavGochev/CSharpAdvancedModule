using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < number; i++)
            {
                string text = Console.ReadLine();
                list.Add(text);
            }
            string compare = Console.ReadLine();
            Console.WriteLine(Box<string>.Return(compare, list));
        }
    }
}
