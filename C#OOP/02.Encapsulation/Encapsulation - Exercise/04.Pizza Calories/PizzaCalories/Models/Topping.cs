using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private const string INVALID_TYPE= "Cannot place {0} on top of your pizza.";
        private const string INVALID_WEIGHT= "{0} weight should be in the range [1..50].";
        private const double GRAMS= 2;
        private const double MAX = 50;
        private const double MIN = 1;
        private string typeOfTopping;
        private double weight;

        public Topping(string typeOfTopping,double weight)
        {
            this.TypeOfTopping = typeOfTopping;
            this.Weight = weight;
        }
        public string TypeOfTopping
        {
            get => this.typeOfTopping;
            private set
            {
                if (!Common.Modifiers.Modifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(INVALID_TYPE, value));
                }
                this.typeOfTopping = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if(value < MIN || value > MAX)
                {
                    throw new ArgumentException(string.Format(INVALID_WEIGHT,this.typeOfTopping));
                }
                this.weight = value;
            }
        }
        public double Calories => Calculate();
        private double Calculate()
        {
            double typeGrams = Common.Modifiers.Modifier[this.typeOfTopping.ToLower()];
            return typeGrams * weight * GRAMS;
        }  
    }
}
