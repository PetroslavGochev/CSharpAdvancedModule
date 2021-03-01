using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.SummerCoctails
{
    class StartUp
    {
        private const string PARTY_TIME = "It's party time! The cocktails are ready!";
        private const string NO_PARTY = "What a pity! You didn't manage to prepare all cocktails.";
        private const string COCKTAIL = " # {0} --> {1}";


        private static IDictionary<int, string> coctail = new Dictionary<int, string>()
            {
                {150,"Mimosa"},
                {250,"Daiquiri"},
                {300,"Sunshine"},
                {400,"Mojito"}
            };
        private static IDictionary<string, int> countOfCoctail = new Dictionary<string, int>()
            {
                {"Mimosa",0},
                {"Daiquiri",0},
                {"Sunshine",0},
                {"Mojito",0}
            };
        private static Queue<int> ingredient = new Queue<int>();
        private static Stack<int> freshLevel = new Stack<int>();
        static void Main(string[] args)
        {
            var ingredientsArgs = ReadDataFromConsole();
            foreach (var i in ingredientsArgs)
            {
                ingredient.Enqueue(i);
            }
            var freshArgs = ReadDataFromConsole();
            foreach (var f in freshArgs)
            {
                freshLevel.Push(f);
            }
            Combination();
            Console.WriteLine(ReturnResult());
            PrintIngredient();
            Console.WriteLine(PrintCoctails());
            
        }
        private static string PrintCoctails()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in countOfCoctail
                                            .Where(x=>x.Value != 0)
                                            .OrderBy(x=>x.Key))
            {
                sb.AppendLine(String.Format(COCKTAIL, item.Key, item.Value));
            }
            return sb.ToString().TrimEnd();
        }
        private static void PrintIngredient()
        {
            int sum = 0;
            while(ingredient.Count != 0)
            {
                sum += ingredient.Dequeue();
            }
            if(sum != 0)
            {
                Console.WriteLine($"Ingredients left: {sum}");
            }
        }
        private static string ReturnResult()
            => countOfCoctail.Any(x => x.Value == 0)
            ? NO_PARTY
            : PARTY_TIME;
        private static void Combination()
        {
            while (IsNotEmpty())
            {
                if(ingredient.Peek() == 0)
                {
                    ingredient.Dequeue();
                    continue;
                }
                if (IsSumEqual())
                {
                    countOfCoctail[coctail[ingredient.Dequeue() * freshLevel.Pop()]]++;
                }
                else
                {
                    ingredient.Enqueue(ingredient.Dequeue() + 5);
                    freshLevel.Pop();
                }
            }
        }
        private static bool IsSumEqual()
            => coctail.ContainsKey(ingredient.Peek() * freshLevel.Peek());
        private static bool IsNotEmpty()
            => ingredient.Count != 0 && freshLevel.Count != 0;
        private static int[] ReadDataFromConsole()
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
