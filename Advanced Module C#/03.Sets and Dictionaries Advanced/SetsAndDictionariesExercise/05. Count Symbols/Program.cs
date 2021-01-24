using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();
            var text = Console.ReadLine();
            foreach (var symbol in text)
            {
                if (!dict.ContainsKey(symbol))
                {
                    dict.Add(symbol, 0);
                }
                dict[symbol]++;
            }
            foreach (var symbol in dict)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }

        }
    }
}
