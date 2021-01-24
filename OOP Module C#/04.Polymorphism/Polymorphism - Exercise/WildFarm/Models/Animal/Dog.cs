namespace WildFarm.Models.Animal
{
    using Food;
    public class Dog : Mammal
    {
        private const double WEIGHT_PER_FOOD = 0.40;
        private const string SOUND = "Woof!";

        public Dog(string name, double weight,  string livingRegion) 
            : base(name, weight,  livingRegion)
        {
        }

        protected override double WeightPerFood => WEIGHT_PER_FOOD;

        protected override bool IsFoodValid(Food food) => food.GetType().Name == "Meat" ? true : false;

        public override string ProduceSound() => SOUND;
        public override string ToString()
        {
            return $"{base.ToString()}{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
