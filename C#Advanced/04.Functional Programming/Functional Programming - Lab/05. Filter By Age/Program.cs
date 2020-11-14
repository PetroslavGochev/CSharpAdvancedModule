using System;

namespace _05._Filter_By_Age
{
    class Program
    {
        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Person[] people = new Person[number];
            for (int i = 0; i < number; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people[i] = new Person() { Name = input[0], Age = int.Parse(input[1]) };
            }
            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<Person, bool> filter = Condition(condition, age);
            Action<Person> print = PrintResult(format);
            foreach (var person in people)
            {
                if (filter(person))
                {
                    print(person);
                }
            }
        }
        static Func<Person, bool> Condition(string condition, int age)
        {
            if (condition == "younger")
            {
                return p => p.Age < age;
            }
            else if (condition == "older")
            {
                return p => p.Age >= age;
            }
            else return null;
        }
        static Action<Person> PrintResult(string format)
        {
            if (format == "name")
            {
                return p => Console.WriteLine($"{p.Name}");
            }
            else if (format == "age")
            {
                return p => Console.WriteLine($"{p.Age}");
            }
            else if (format == "name age")
            {
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
            }
            return null;
        }
    }
}
