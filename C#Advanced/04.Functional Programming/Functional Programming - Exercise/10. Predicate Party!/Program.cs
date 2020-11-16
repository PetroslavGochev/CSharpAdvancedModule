using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            string input = string.Empty;
            Func<string, string, string, bool> isValid = (firsOrlast, name, pattern) =>
               {
                   bool flag = true;
                   if (firsOrlast == "StartsWith")
                   {
                       flag = name.StartsWith(pattern) ? true : false;
                   }
                   else if (firsOrlast == "EndsWith")
                   {
                       flag = name.EndsWith(pattern) ? true : false;
                   }
                   else if (firsOrlast == "Length")
                   {
                       flag = name.Length == int.Parse(pattern) ? true : false;
                   }
                   return flag;
               };
            Predicate<List<string>> isEmpty = list => list.Count != 0;
            Action<List<string>> printResult = guests =>
            {
                if (isEmpty(guests))
                {
                    Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
                    return;
                }
                Console.WriteLine("Nobody is going to the party!");
            };
            while ((input = Console.ReadLine()) != "Party!")
            {
                var data = input
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();
                string command = data[0];
                string criteria = data[1];
                string pattern = data[2];
                if (command == "Double")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (isValid(criteria, guests[i], pattern))
                        {
                            guests.Insert(i, guests[i]);
                            i++;
                        }
                    }
                }
                else if (command == "Remove")
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (isValid(criteria, guests[i], pattern))
                        {
                            guests.RemoveAll(x => x == guests[i]);
                        }
                    }
                }
            }
            printResult(guests);
        }
    }
}

