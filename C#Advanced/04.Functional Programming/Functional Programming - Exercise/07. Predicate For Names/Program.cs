using System;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries);
            Predicate<string> isValid = name => name.Length <= number;
            foreach (var name in names)
            {
                if (isValid(name))
                {
                    Console.WriteLine($"{name}");
                }
            }
        }
    }
}
