using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> index = new Stack<int>();
            string result = string.Empty;
            for (int i = 0; i < input.Length;i++)
            {
                if(input[i] == '(' )
                {
                    index.Push(i);
                }
                else if (input[i] == ')')
                {
                    int finalIndex = i - index.Pop();
                    result = input.Substring(i - finalIndex,finalIndex+1);
                    Console.WriteLine(result);
                }
            }
        }
    }
}
