namespace WildFarm.Models.Animal
{
    using Food;

    public class Mouse : Mammal
    {
        private const double WEIGHT_PER_FOOD = 0.10;
        private const string SOUND = "Squeak";

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightPerFood => WEIGHT_PER_FOOD;

        protected override bool IsFoodValid(Food food) => food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit" ? true : false;

        public override string ProduceSound() => SOUND;
        public override string ToString()
        {
            return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }

    }
}
