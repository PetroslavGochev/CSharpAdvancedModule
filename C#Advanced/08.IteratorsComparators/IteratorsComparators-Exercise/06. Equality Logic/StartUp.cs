using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var person = new Person(input[0], int.Parse(input[1]));
                sortedSet.Add(person);
                hashSet.Add(person);

            }
            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);

        }
    }
}
