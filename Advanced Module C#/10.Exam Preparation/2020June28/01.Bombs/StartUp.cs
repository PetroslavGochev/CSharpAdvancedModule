using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Bombs
{
    class StartUp
    {
        private static Dictionary<int, string> bombPouch = new Dictionary<int, string>()
        {
            { 40,"Datura Bombs" },
            { 60,"Cherry Bombs" },
            { 120,"Smoke Decoy Bombs" }
        };
        private static SortedDictionary<string, int> filledBomb = new SortedDictionary<string, int>()
        {
            {"Datura Bombs",0},
            {"Cherry Bombs",0 },
            {"Smoke Decoy Bombs",0 }
        };

        private static Queue<int> bombEffects = new Queue<int>();
        private static Stack<int> bombCasing = new Stack<int>();
        static void Main(string[] args)
        {
            int[] effectArgs = ReadArgsFromConsole();
            foreach (var e in effectArgs)
            {
                bombEffects.Enqueue(e);
            }
            int[] casingArgs = ReadArgsFromConsole();
            foreach (var c in casingArgs)
            {
                bombCasing.Push(c);
            }
            Console.WriteLine(Combination());
            Console.WriteLine(PrintBombCasingAndEffects());
            foreach (var fb in filledBomb)
            {
                Console.WriteLine($"{fb.Key}: {fb.Value}");
            }
        }
        private static string PrintBombCasingAndEffects()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Bomb Effects: ");
            if (bombEffects.Count == 0)
            {
                sb.AppendLine("empty");
            }
            else
            {
                while (bombEffects.Count != 0)
                {
                    if(bombEffects.Count == 1)
                    {
                        sb.AppendLine($"{bombEffects.Dequeue()}");
                        break;
                    }
                    sb.Append($"{bombEffects.Dequeue()}, ");
                }
            }
            sb.Append($"Bomb Casings: ");
            if (bombCasing.Count == 0)
            {
                sb.AppendLine("empty");
            }
            else
            {
                while (bombCasing.Count != 0)
                {
                    if(bombCasing.Count == 1)
                    {
                        sb.AppendLine($"{bombCasing.Pop()}");
                        break;
                    }
                    sb.Append($"{bombCasing.Pop()}, ");
                }             
            }
            return sb.ToString().TrimEnd();
        }
        private static int[] ReadArgsFromConsole()
            => Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        private static string Combination()
        {
            while(bombCasing.Count != 0 && bombEffects.Count != 0)
            {
                int sum = bombCasing.Peek() + bombEffects.Peek();
                if (bombPouch.ContainsKey(sum))
                {
                    filledBomb[bombPouch[sum]]++;
                    bombCasing.Pop();
                    bombEffects.Dequeue();
                }
                else
                {
                    sum = bombCasing.Pop() - 5;
                    bombCasing.Push(sum);
                }
                if (!IsAllBombFilled())
                {

                    return "Bene! You have successfully filled the bomb pouch!";
                }
            }
            return "You don't have enough materials to fill the bomb pouch.";
        }
        private static bool IsAllBombFilled()
            => filledBomb.Any(x => x.Value < 3);           
    }
}
