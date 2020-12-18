using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Models
{
    public class Dough
    {
        private const double GRAMS = 2;
        private const double MAX = 200;
        private const double MIN = 1;
        private const string INVALID_DOUGH = "Invalid type of dough.";
        private const string INVALID_GRAMS = "Dough weight should be in the range [1..200].";
        private string flourType;
        private string technique;
        private double weight;

        public Dough(string flourType, string technique,double weight)
        {
            this.FlourType = flourType;
            this.Technique = technique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get => this.flourType;
            private set
            {
                if (!Common.Modifiers.Modifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(INVALID_DOUGH);
                }
               this.flourType = value;
            }
        }

        public string Technique
        {
            get => this.technique;
            private set
            {
                if (!Common.Modifiers.Modifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(INVALID_DOUGH);
                }
                this.technique = value;
            }
        }
        public double Weight
        {
            get => this.weight;
            private set
            {
                if(value > MAX || value < MIN)
                {
                    throw new ArgumentException(INVALID_GRAMS);
                }
                this.weight = value;
            }
        }
        public double Calories => Calculate();

        private double Calculate()
        {
            double technique = Common.Modifiers.Modifier[this.Technique.ToLower()];
            double type = Common.Modifiers.Modifier[this.flourType.ToLower()];
            return technique * type * weight * GRAMS;
        }
    }
}
