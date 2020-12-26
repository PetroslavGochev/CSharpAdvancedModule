using System;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION = 1.6;
        private const double PROBLEM = 0.95;

        public Truck(double fuelQuantity, double fuelConsumtpion) 
            : base(fuelQuantity, fuelConsumtpion)
        {
        }

        public override void Driving(double distance)
        {
            double distanceWithFuel = distance * (this.FuelConsumption + AIR_CONDITION);
            if(distanceWithFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= distanceWithFuel;
                Console.WriteLine(String.Format(GlobalConstants.TRAVELED_DISTANCE, GetType().Name, distance));
            }
            else
            {
                Console.WriteLine(String.Format(GlobalConstants.NEED_REFUELING, GetType().Name));
            }
        }

        public override void Refueling(double liters)
        {

            this.FuelQuantity += liters * PROBLEM;
        }
    }
}
