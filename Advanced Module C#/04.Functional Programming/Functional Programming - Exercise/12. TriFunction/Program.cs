using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            Func<string, int, bool> checkSumOfName = (name, value) =>
            {
                int sumOfName = 0;
                foreach (var character in name)
                {
                    sumOfName += character;
                }
                return sumOfName >= value;
            };
            Func<Func<string,int,bool>, List<string>, int, string> printName = (func, names, value) =>
               {
                   string win = string.Empty;
                   foreach (var name in names)
                   {
                       if (func(name, value))
                       {
                           win = name;
                           return win;
                       }
                   }
                   return win;
               };
            Console.WriteLine(printName(checkSumOfName, names, number));
        }

    }
    
}
