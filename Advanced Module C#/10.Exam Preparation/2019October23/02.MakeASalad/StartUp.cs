using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MakeASalad
{
    class StartUp
    {
        private static Dictionary<string, int> vegetablesCalories = new Dictionary<string, int>()
        {
            {"tomato",80},
            {"carrot",136},
            {"lettuce",109},
            {"potato",215}
        };

        private static List<int> listOfSalads = new List<int>();
        private static Queue<string> vegetables = new Queue<string>();
        private static Stack<int> calories = new Stack<int>();
        private static int neededCalories;
        private static int sum;
        static void Main(string[] args)
        {
            string[] vegetableArgs = ReadDataFromConsole();
            foreach (var v in vegetableArgs)
            {
                vegetables.Enqueue(v);
            }
            string[] caloriesArgs = ReadDataFromConsole();
            foreach (var c in caloriesArgs)
            {
                calories.Push(int.Parse(c));
            }
            Combination();
            PrintResult();
        }

        private static void Combination()
        {
            while (IsTrue())
            {
                neededCalories = calories.Peek();
                sum += vegetablesCalories[vegetables.Dequeue()];
                if (sum >= neededCalories)
                {
                    listOfSalads.Add(calories.Pop());
                    sum = sum - neededCalories;
                }
            }
        }

        private static bool IsTrue()
            => vegetables.Count != 0 && calories.Count != 0;
        private static string[] ReadDataFromConsole()
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" ", listOfSalads));
            if (vegetables.Count == 0)
            {
                while (calories.Count != 0)
                {
                    Console.Write($"{calories.Pop()} ");
                }
            }
            else
            {
                while (vegetables.Count != 0)
                {
                    Console.Write($"{vegetables.Dequeue()} ");
                }
            }
            Console.WriteLine();
        }
    }
}

