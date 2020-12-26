using System;
using Vehicles.Common;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION = 1.6;
        private const bool hole = true;

        public Truck(double fuelQuantity, double fuelConsumtpion)
            : base(fuelQuantity, fuelConsumtpion)
        {
        }

        protected override double AirCondition => AIR_CONDITION;

        protected override bool Hole => hole;
    }
}
