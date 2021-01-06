using PizzaCalories.Common;
using System;

namespace PizzaCalories.Model
{
    public class Topping
    {
        private const string INVALID_TYPE = "Cannot place {0} on top of your pizza.";
        private const string INVALID_WEIGHT = "{0} weight should be in the range [1..50].";
        private const double CALORIES_PER_GRAM = 2.00;
        private const double MINIMUM = 0;
        private const double MAXIMUM = 50;

        private string typeOfMeat;
        private double weight;
        public Topping(string typeOfMeat,double weight)
        {
            this.TypeOfMeat = typeOfMeat;
            this.Weight = weight;
        }
        public string TypeOfMeat
        {
            get
            {
                return this.typeOfMeat;
            }
            set
            {
                if (!Modifiers.Modifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(String.Format(INVALID_TYPE,value));
                }
                this.typeOfMeat = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (value < MINIMUM || value > MAXIMUM)
                {
                    throw new ArgumentException(String.Format(INVALID_WEIGHT,this.TypeOfMeat));
                }
                this.weight = value;
            }
        }
        public double Calories => CalculateCalories();
        private double CalculateCalories()
        {
            double totalCalories = CALORIES_PER_GRAM * this.Weight * Modifiers.Modifier[this.TypeOfMeat.ToLower()];
            return totalCalories;
        }
    }
}
