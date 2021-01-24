using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int push = input[0];
            int pop = input[1];
            int number = input[2];
            Stack<int> stackNumbers = new Stack<int>();
            for (int i = 0; i < push; i++)
            {
                stackNumbers.Push(numbers[i]);
            }
            for (int i = 0; i < pop; i++)
            {
                stackNumbers.Pop();
            }
            if (stackNumbers.Contains(number))
            {
                Console.WriteLine("true");
            }
            else if (stackNumbers.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                int smallest = int.MaxValue;
                foreach (var item in stackNumbers)
                {
                    if (item < smallest)
                    {
                        smallest = item;
                    }
                }
                Console.WriteLine(smallest);
            }
        }
    }
}
