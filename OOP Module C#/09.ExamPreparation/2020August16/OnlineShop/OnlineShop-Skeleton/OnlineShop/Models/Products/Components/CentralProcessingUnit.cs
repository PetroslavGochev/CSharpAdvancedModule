namespace OnlineShop.Models.Products.Components
{
    public class CentralProcessingUnit : Component
    {
        
        public CentralProcessingUnit(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) 
            : base(id, manufacturer, model, price, overallPerformance, generation)
        {
         
        }

        protected override double Multiplier => 1.25;
    }
}
