namespace WildFarm.Models.Animal
{
    using Food;
    public class Owl : Bird
    {   
        private const double WEIGHT_PER_FOOD = 0.25;
        private const string SOUND = "Hoot Hoot";
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight,  wingSize)
        {
        }

        protected override double WeightPerFood => WEIGHT_PER_FOOD;

        protected override bool IsFoodValid(Food food) => food.GetType().Name == "Meat" ? true : false;

        public override string ProduceSound() => SOUND;
        
    }
}
