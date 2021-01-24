using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Reverse()
                 .ToArray();
            Stack<string> calculate = new Stack<string>(input);
            while(calculate.Count > 1)
            {
                int firstNumber = int.Parse(calculate.Pop());
                string action = calculate.Pop();
                int secondNumber = int.Parse(calculate.Pop());
                if(action == "+")
                {
                    calculate.Push((firstNumber + secondNumber).ToString());
                }
                else if(action == "-")
                {
                    calculate.Push((firstNumber - secondNumber).ToString());
                }
            }
            Console.WriteLine(calculate.Pop());
        }
    }
}
