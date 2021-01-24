using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = (string[])Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Stack<string> text = new Stack<string>();
            
            foreach (var item in input)
            {
                string reverse = string.Empty;
                for (int i = item.Length-1; i >= 0; i--)
                {
                    reverse += item[i];
                }
                text.Push(reverse);
            }
           
            while(text.Count > 0)
            {
                Console.Write($"{text.Pop()} ");
            }
        }
    }
}
