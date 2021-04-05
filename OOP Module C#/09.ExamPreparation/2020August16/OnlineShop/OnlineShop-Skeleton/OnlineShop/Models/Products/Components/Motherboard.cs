namespace OnlineShop.Models.Products.Components
{
    public class Motherboard : Component
    {
        public Motherboard(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {
        }

        protected override double Multiplier => 1.25;
    }
}
