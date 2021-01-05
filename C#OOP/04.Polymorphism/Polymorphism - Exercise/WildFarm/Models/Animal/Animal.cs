namespace WildFarm.Models.Animal
{
    using WildFarm.Models.Animal.Contracts;
    using Food;
    using System;

    public abstract class Animal : IAnimal
    {
        public const string INVALID_FOOD = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name {get;}

        public double Weight { get;  set; }

        public int FoodEaten { get;  set; }

        protected abstract double WeightPerFood { get; }

        

        public virtual void Eat(Food food)
        {
            if (!IsFoodValid(food))
            {
                throw new ArgumentException(String.Format(INVALID_FOOD, this.GetType().Name, food.GetType().Name));
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.WeightPerFood;
        }

        protected abstract bool IsFoodValid(Food food);

        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

        
    }
}
