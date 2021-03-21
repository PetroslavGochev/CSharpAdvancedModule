using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DatingApp
{
    class StartUp
    {
        private const string MATCHES = "Matches: {0}";
        private const string MALE = "Males left: ";
        private const string FEMALE = "Females left: ";

        private static int matchesCouple = 0;
        private static Queue<int> female = new Queue<int>();
        private static Stack<int> male = new Stack<int>();
        static void Main(string[] args)
        {
            var maleArgs = ReadDataFromConsole();
            foreach (var m in maleArgs)
            {
                male.Push(m);
            }
            var femaleArgs = ReadDataFromConsole();
            foreach (var f in femaleArgs)
            {
                female.Enqueue(f);
            }
            
            MatchCouple();
            PrintResult();
        }
        private static void PrintResult()
        {
            Console.WriteLine(String.Format(MATCHES, matchesCouple));
            if(male.Count == 0)
            {
                Console.WriteLine($"{MALE}none");
            }
            else
            {
                Console.Write($"{MALE}");
                while(male.Count != 0)
                {
                    if(male.Count == 1)
                    {
                        Console.WriteLine($"{male.Pop()}");
                        break;
                    }
                    Console.Write($"{male.Pop()}, ");
                }
            }
            if (female.Count == 0)
            {
                Console.WriteLine($"{FEMALE}none");
            }
            else
            {
                Console.Write($"{FEMALE}");
                while (female.Count != 0)
                {
                    if (female.Count == 1)
                    {
                        Console.WriteLine($"{female.Dequeue()}");
                        break;
                    }
                    Console.Write($"{female.Dequeue()}, ");
                }
            }
        }
        private static void MatchCouple()
        {
            while (IsTrue())
            {
                if (ValueIsNullOrBelow(female.Peek()))
                {
                    female.Dequeue();
                    continue;
                }
                if (ValueIsNullOrBelow(male.Peek()))
                {
                    male.Pop();
                    continue;
                }
                if (DivisbleBy25WithoutReminder(female.Peek()))
                {
                    female.Dequeue();
                    if(female.Count >= 1)
                    {
                        female.Dequeue();
                    }
                    continue;
                }
                if (DivisbleBy25WithoutReminder(male.Peek()))
                {
                    male.Pop();
                    if(male.Count >= 1)
                    {
                        male.Pop();
                    }
                    continue;
                }
                if (IsEqual())
                {
                    matchesCouple++;
                    male.Pop();
                    female.Dequeue();
                }
                else
                {
                    female.Dequeue();
                    male.Push(male.Pop() - 2);
                }
            }
            
        }
        private static bool DivisbleBy25WithoutReminder(int value)
            => value % 25 == 0;
        private static bool ValueIsNullOrBelow(int value)
            => value <= 0;
        private static bool IsTrue()
            => female.Count != 0 && male.Count != 0;
        private static bool IsEqual()
            => female.Peek() == male.Peek();
        private static int[] ReadDataFromConsole()
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
