using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            List<Person> listOfPeople = new List<Person>();
            while ((input = Console.ReadLine()) != "END")
            {
                var data = input.Split();
                var person = new Person(data[0], int.Parse(data[1]), data[2]);
                listOfPeople.Add(person);
            }
            int number = int.Parse(Console.ReadLine());
            int equal = 0;
            int noEqual = 0;
            Person matchPerson = listOfPeople[number - 1];
            foreach (var person in listOfPeople)
            {
                if(person.CompareTo(matchPerson) == 0)
                {
                    equal++;
                }
                else
                {
                    noEqual++;
                }
            }
            if(equal == 1)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine($"{equal} {noEqual} {listOfPeople.Count}");
        }
    }
}
