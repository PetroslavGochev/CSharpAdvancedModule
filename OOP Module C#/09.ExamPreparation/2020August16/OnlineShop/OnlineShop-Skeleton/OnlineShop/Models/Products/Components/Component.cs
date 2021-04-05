namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
            overallPerformance *= this.Multiplier;
        }

        public int Generation { get; private set; }

        protected abstract double Multiplier { get; }

        public override string ToString()
        {
            return base.ToString() + $" Generation: {this.Generation}";
        }
    }
}
