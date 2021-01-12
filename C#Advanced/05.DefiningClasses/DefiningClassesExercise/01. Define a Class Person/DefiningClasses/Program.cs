using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Person person1 = new Person("Ivan", 48);
            //Person person2 = new Person("Stamat", 31);
            //Console.WriteLine($"{person1.Name} - {person1.Age}");
            //Console.WriteLine($"{person2.Name} - {person2.Age}");

            
            int number = int.Parse(Console.ReadLine());
            Family members = new Family();
            for (int i = 1; i <= number; i++)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                var name = input[0];
                var age = int.Parse(input[1]);
                Person person = new Person(name, age);
                members.AddMember(person);
            }
            Person oldest = members.GetOldestMember(members);
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
            //members
            //     .Where(x => x.Age > 30)
            //     .OrderBy(x => x.Name)
            //     .ToList()
            //     .ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
        }
    }
}

