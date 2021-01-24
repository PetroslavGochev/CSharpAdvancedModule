using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = string.Empty;
            Action<int[]> printArray = array =>
            {
                Console.WriteLine(string.Join(" ", array));
            };
            Func<int[], string, int[]> arrayManipualtor = (collection, input) =>
              {
                  if (input == "add") return collection.Select(x => x + 1).ToArray();
                  else if (input == "multiply") return collection.Select(x => x * 2).ToArray();
                  return collection.Select(x => x - 1).ToArray();
              };
            while ((input = Console.ReadLine()) != "end")
            {
                if(input == "print")
                {
                    printArray(collection);
                }
                else
                {
                  collection = arrayManipualtor(collection, input);
                }
            }
        }      
    }
}
