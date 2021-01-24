using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackSum = new Stack<int>(number);
            string input = string.Empty;
            while((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if(command[0] == "add")
                {
                    for (int i = 1; i < command.Length; i++)
                    {
                        stackSum.Push(int.Parse(command[i]));
                    }
                }
                else if (command[0] == "remove")
                {
                    if(int.Parse(command[1]) <= stackSum.Count)
                    {
                        for (int i = 0; i < int.Parse(command[1]); i++)
                        {
                            stackSum.Pop();
                        }
                    }      
                }
            }
            Console.WriteLine($"Sum: {stackSum.Sum()}");
        }
    }
}
