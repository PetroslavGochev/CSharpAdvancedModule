using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCalories.Model
{
    public class Pizza
    {
        private const string INVALID_NAME = "Pizza name should be between 1 and 15 symbols.";
        private const string OUT_OF_RANGE = "Number of toppings should be in range [0..10].";
        private string name;
        private Dough dough;
        private ICollection<Topping> toppings;
        private Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name,Dough dough)
            : this()
        {
            this.Name = name;
            this.dough = dough;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException(INVALID_NAME);
                }
                this.name = value;
            }
        }
        public double PizzaCalories => this.dough.Calories + this.toppings.Sum(x => x.Calories);

        public void AddToppings(Topping topping)
        {
            if(this.toppings.Count == 10)
            {
                throw new ArgumentException(OUT_OF_RANGE);
            }
            toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.PizzaCalories:f2} Calories.";
        }
    }
}
