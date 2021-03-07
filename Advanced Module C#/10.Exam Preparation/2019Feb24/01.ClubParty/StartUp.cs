using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    class StartUp
    {
        private const string PRINT_HALL = "{0} -> ";

        private static int maxCapacity;
        private static Dictionary<char, List<int>> halls = new Dictionary<char, List<int>>();
        private static Stack<string> input = new Stack<string>();
        static void Main(string[] args)
        {
            maxCapacity = int.Parse(Console.ReadLine());
            var inputArgs = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();
            foreach (var item in inputArgs)
            {
                input.Push(item);
            }
            FillHall();
        }
        private static void FillHall()
        {
            while (IsTrue())
            {
                if (input.Peek().Length < 2 && IsLetter())
                {
                    halls.Add(char.Parse(input.Pop()), new List<int>());
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        input.Pop();
                    }
                    else
                    {
                        AddReservationInHall();
                    }
                }
            }
        }
        private static void AddReservationInHall()
        {
            var hal = halls.First();
            if (hal.Value.Sum() + int.Parse(input.Peek()) < maxCapacity)
            {
                halls[hal.Key].Add(int.Parse(input.Pop()));
            }
            else
            {
                PrintHall();
            }
        }
        private static void PrintHall()
        {
            int currentReservation = int.Parse(input.Peek());

            var hal = halls.First();
            if (hal.Value.Sum() + currentReservation == maxCapacity)
            {
                halls[hal.Key].Add(int.Parse(input.Pop()));
            }
            else
            {
                input.Pop();
            }
            Console.Write(String.Format(PRINT_HALL, hal.Key));
            for (int i = 0; i < hal.Value.Count; i++)
            {
                if (i == hal.Value.Count - 1)
                {
                    Console.WriteLine($"{hal.Value[i]}");
                    break;
                }
                Console.Write($"{hal.Value[i]}, ");
            }
            halls.Remove(hal.Key);
            if (halls.Count != 0)
            {
                input.Push(currentReservation.ToString());
                AddReservationInHall();
            }

        }

        private static bool IsLetter() => char.IsLetter(char.Parse(input.Peek()));
        private static bool IsTrue() => input.Count != 0;
    }
}
