using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            List<Animals> list = new List<Animals>();
            while ((input = Console.ReadLine()) != "Beast!")
            {
                try
                { 
                var data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var type = input;
                var name = data[0];
                var age = int.Parse(data[1]);
                var gender = data[2];
                Animals animal = null;
                    if (type == "Dog")
                    {
                        animal = new Dog(name, age, gender);
                    }
                    else if (type == "Cat")
                    {
                        animal = new Cat(name, age, gender);
                    }
                    else if (type == "Frog")
                    {
                        animal = new Frog(name, age, gender);
                    }
                    else if (type == "Kitten")
                    {
                        animal = new Kitten(name, age);
                    }
                    else if (type == "Tomcat")
                    {
                        animal = new Tomcat(name, age);
                    }
                    list.Add(animal);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            foreach (var animal in list)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
