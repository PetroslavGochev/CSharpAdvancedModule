namespace MXGP.Models.Motorcycles.Models
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450;
        
        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {
            this.minimumHorsePower = 70;
            this.maximumHorsePower = 100;
        }

    }
}
