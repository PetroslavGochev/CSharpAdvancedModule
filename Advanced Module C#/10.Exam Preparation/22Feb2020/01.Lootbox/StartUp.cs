using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class StartUp
    {
        private const string POOR_SUM = "Your loot was poor... Value: {0}";
        private const string EPIC_SUM = "Your loot was epic! Value: {0}";
        private const string FIRST_LOTBOX = "First lootbox is empty";
        private const string SECOND_LOTBOX = "Second lootbox is empty";
        private const int NEEDED_SUM = 100;

        private static int sum = 0;
        private static Queue<int> first = new Queue<int>();
        private static Stack<int> second = new Stack<int>();
        static void Main(string[] args)
        {
            int[] firstArgs = ReadDataFromConsole();
            foreach (var f in firstArgs)
            {
                first.Enqueue(f);
            }
            int[] secondArgss = ReadDataFromConsole();
            foreach (var s in secondArgss)
            {
                second.Push(s);
            }
            Combination();
            Console.WriteLine(ReturnResult());
            Console.WriteLine(String.Format(IsSumEnough(),sum));
        }

        private static void Combination()
        {
            while (IsTrue())
            {
                if (IsSumEven())
                {
                    sum += first.Dequeue() + second.Pop();
                }
                else
                {
                    first.Enqueue(second.Pop());
                }
            }       
        }

        private static string ReturnResult()
            => first.Count == 0 ? FIRST_LOTBOX : SECOND_LOTBOX;
        private static string IsSumEnough()
            => sum >= NEEDED_SUM ? EPIC_SUM : POOR_SUM;
        private static bool IsTrue()
            => first.Count != 0 && second.Count != 0;
        private static bool IsSumEven()
            => (first.Peek() + second.Peek()) % 2 == 0;
        private static int[] ReadDataFromConsole()
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
