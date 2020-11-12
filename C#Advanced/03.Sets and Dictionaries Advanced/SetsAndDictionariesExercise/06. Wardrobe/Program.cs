using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 1; i <= number; i++)
            {
                var input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var color = input[0];
                var clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int k = 0; k < clothes.Length; k++)
                {                  
                    if (!wardrobe[color].ContainsKey(clothes[k]))
                    {
                        wardrobe[color].Add(clothes[k], 0);
                    }
                    wardrobe[color][clothes[k]]++;
                }
            }
            var command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var color  in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothes in color.Value)
                {
                    if(clothes.Key == command[1] && color.Key == command[0])
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                }
            }
 
        }
    }
}
