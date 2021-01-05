namespace WildFarm.Models.Animal.Contracts
{
    using Food;

    public interface IAnimal
    {
        public string  Name { get;}
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public abstract void Eat(Food food);
        public abstract string ProduceSound();

    }
}
