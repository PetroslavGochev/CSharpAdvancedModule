using FoodShortage.Contract;
using FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<IBuy> listOfPerson = new List<IBuy>();
            for (int i = 1; i <= number; i++)
            {
                string[] data = Console.ReadLine()
                    .Split();
                string name = data[0];
                int age = int.Parse(data[1]);
                if (data.Length == 4)
                {
                    string id = data[2];
                    string birthdate = data[3];
                    IBuy citizen = new Citizen(name, age, id, birthdate);
                    listOfPerson.Add(citizen);
                }
                else if (data.Length == 3)
                {
                    string group = data[2];
                    IBuy rebel = new Rebel(name, age, group);
                    listOfPerson.Add(rebel);
                }
            }
            string input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                foreach (var person in listOfPerson)
                {
                    if(person.Name == input)
                    {
                        person.BuyFood();
                    }
                }
            }
            int total = 0;
            foreach (var person in listOfPerson)
            {
                total += person.Food;
            }
            Console.WriteLine(total);
        }
    }
}
