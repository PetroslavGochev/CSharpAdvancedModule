using System;
using Vehicles.Common;

namespace Vehicles.Models
{

    public class Car : Vehicle
    {
        private const double AIR_CONDITION = 0.9;
        private const bool hole = false;
        public Car(double fuelQuantity, double fuelConsumtpion) 
            : base(fuelQuantity, fuelConsumtpion)
        {
           
        }

        protected override double AirCondition => AIR_CONDITION;

        protected override bool Hole => hole;
    }
}
