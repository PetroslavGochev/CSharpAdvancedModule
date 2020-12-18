using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private const string INVALID_NAME = "Pizza name should be between 1 and 15 symbols.";
        private const string OUT_OF_RANGE = "Number of toppings should be in range [0..10].";
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name, Dough dough)
            :this()
        {
            this.name = name;
            this.dough = dough;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < 1 || value.Length >15)
                {
                    throw new ArgumentException(INVALID_NAME);
                }
                this.name = value;
            }
        }
        public double TotalCalories => dough.Calories + toppings.Sum(x => x.Calories);

        public void AddTopping(Topping topping)
        {
            toppings.Add(topping);
            if (toppings.Count > 10)
            {
                throw new ArgumentException(OUT_OF_RANGE);
            }
        }

        public override string ToString() => $"{this.Name} - {this.TotalCalories:f2} Calories.";
       
    }
}
