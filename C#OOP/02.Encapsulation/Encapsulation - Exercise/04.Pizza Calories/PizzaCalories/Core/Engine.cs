using PizzaCalories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Core
{
    public class Engine
    {
        private const string INVALID_NAME = "Pizza name should be between 1 and 15 symbols.";
        private const string INVALID_DOUGH = "Invalid type of dough.";

        public void Run()
        {
            string[] pizzaData = ConsoleRead();
            if(pizzaData.Length <2 )
            {
                throw new ArgumentException(INVALID_NAME);
            }
            var pizzaName = pizzaData[1];
            string[] doughData = ConsoleRead();
            if(doughData.Length < 2)
            {
                throw new ArgumentException(INVALID_DOUGH);
            }
            var doughType = doughData[1];
            var doughTechnique = doughData[2];
            var doughWeight = double.Parse(doughData[3]);
            string toppingInput = string.Empty;
            try
            {
                Dough dough = new Dough(doughType, doughTechnique, doughWeight);
                Pizza pizza = new Pizza(pizzaName, dough);
                while ((toppingInput = Console.ReadLine()) != "END")
                {
                    var toppingData = toppingInput.Split();
                    var toppingType = toppingData[1];
                    var toppingWeight = double.Parse(toppingData[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        private string[] ConsoleRead() => Console.ReadLine()
            .Split(" ",StringSplitOptions.RemoveEmptyEntries);
    }
}
