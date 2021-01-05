using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.Models.Animal;
using WildFarm.Models.Food;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            string input = string.Empty;
            List<Animal> listOfAnimals = new List<Animal>();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] animalData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string[] foodData = ReadFromConsole();
                Animal animal = AnimalFactory.CreateAnimal(animalData);
                listOfAnimals.Add(animal);
                Food food = FoodFactory.CreateFood(foodData);
                Console.WriteLine(animal.ProduceSound());
                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }  
            }
            listOfAnimals.ForEach(Console.WriteLine);
        }
        private string[] ReadFromConsole() 
            => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}
