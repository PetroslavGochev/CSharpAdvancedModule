using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TrojanInvasion
{
    class StartUp
    {
        private const string PLATE_WINNER = "The Spartans successfully repulsed the Trojan attack.";
        private const string WARRIOR_WINNER = "The Trojans successfully destroyed the Spartan defense.";

        private static Stack<int> plate = new Stack<int>();
        private static Stack<int> warrior = new Stack<int>();
        static void Main(string[] args)
        {
            CreateTrojanAndSpartans();
            PrintWinner();
        }
        private static void CreateTrojanAndSpartans()
        {
            int numberOfWaves = int.Parse(Console.ReadLine());
            int[] trojanPlate = ReadDataFromConsole();
            EnqueueTrojansInQueue(trojanPlate);
            for (int i = 1; i <= numberOfWaves; i++)
            {
                int[] spartansArgs = ReadDataFromConsole();
                if (i % 3 == 0)
                {
                    trojanPlate = ReadDataFromConsole();
                    EnqueueTrojansInQueue(trojanPlate);
                }
                if (plate.Count == 0)
                {
                    break;
                }
                foreach (var s in spartansArgs)
                {
                    warrior.Push(s);
                }
                Battle();
            }
        }
        private static void PrintWinner()
        {
            Console.WriteLine(Winner());
            if (plate.Count > 0)
            {
                PrintRestValue(plate, "Plates");
            }
            else
            {
                PrintRestValue(warrior, "Warriors");
            }
        }
        private static void PrintRestValue(Stack<int> args,string winner)
        {
            Console.Write($"{winner} left: ");
            while (args.Count != 0)
            {
                if(args.Count == 1)
                {
                    Console.Write($"{args.Pop()}");
                    break;
                }
                Console.Write($"{args.Pop()}, ");
            }
            Console.WriteLine();
        }
        private static string Winner()
         => plate.Count > 0 ? PLATE_WINNER : WARRIOR_WINNER;
        private static void Battle()
        {
            while (warrior.Count != 0 && plate.Count != 0)
            {
                int compare = plate.Peek().CompareTo(warrior.Peek());
                if (compare > 0)
                {
                    plate.Push(plate.Pop() - warrior.Pop());
                }
                else if (compare == 0)
                {
                    plate.Pop();
                    warrior.Pop();
                }
                else
                {
                    warrior.Push(warrior.Pop() - plate.Pop());
                }
            }
        }
        private static void EnqueueTrojansInQueue(int[] args)
        {
            for (int i = args.Length - 1; i >= 0; i--)
            {
                plate.Push(args[i]);
            }
        }
        private static int[] ReadDataFromConsole()
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
