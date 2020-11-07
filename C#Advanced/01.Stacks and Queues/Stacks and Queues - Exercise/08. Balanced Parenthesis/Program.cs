using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
       
            Stack<char> list = new Stack<char>();
            foreach (var symbol in input)
            {
                if (list.Any())
                {
                    char symbolInList = list.Peek();
                    if(symbolInList == '(' && symbol == ')')
                    {
                        list.Pop();
                        continue;
                    }
                    else if(symbolInList == '{' && symbol == '}')
                    {
                        list.Pop();
                        continue;
                    }
                    else if(symbolInList == '[' && symbol == ']')
                    {
                        list.Pop();
                        continue;
                    }
                }
                list.Push(symbol);
            }
            string result = list.Count == 0 ? "YES" : "NO";
            Console.WriteLine(result);



        }
    }
}
