using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> upperCase = x => x[0] == x.ToUpper()[0];
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(upperCase)
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, text));
        }
        
    }
}
