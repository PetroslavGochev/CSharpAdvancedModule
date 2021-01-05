namespace WildFarm.Models.Animal
{
    using Food;

    public class Tiger : Feline
    {
        private const double WEIGHT_PER_FOOD = 1.00;
        private const string SOUND = "ROAR!!!";

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightPerFood => WEIGHT_PER_FOOD;

        protected override bool IsFoodValid(Food food) => food.GetType().Name == "Meat" ? true : false;

        public override string ProduceSound() => SOUND;
      
    }
}
