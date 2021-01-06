using PizzaCalories.Common;
using System;

namespace PizzaCalories.Model
{
   
    public class Dough
    {
        private const string INVALID_FLOUR = "Invalid type of dough.";
        private const string INVALID_WEIGHT = "Dough weight should be in the range [1..200].";
        private const double CALORIES_PER_GRAM = 2.00;
        private const double MINIMUM = 0;
        private const double MAXIMIUM = 200;

        private string flourType;
        private string backingTechnique;
        private double weight;
        public Dough(string flourType,string backingTechnique,double weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if (!Modifiers.Modifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(INVALID_FLOUR);
                }
                this.flourType = value;
            }
        }
        public string BackingTechnique
        {
            get
            {
                return this.backingTechnique;
            }
            set
            {
                if (!Modifiers.Modifier.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(INVALID_FLOUR);
                }
                this.backingTechnique = value;
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
                if(value < MINIMUM || value > MAXIMIUM)
                {
                    throw new ArgumentException(INVALID_WEIGHT);
                }
                this.weight = value;
            }
        }
        public double Calories => CalculateCalories();
        private double CalculateCalories()
        {
            double calories = CALORIES_PER_GRAM * this.Weight * Modifiers.Modifier[this.FlourType.ToLower()] * Modifiers.Modifier[this.BackingTechnique.ToLower()];
            return calories;
        }
    }
}
