using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITION = 0.9;
        private const bool hole = false;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }
        protected override double AirCondition => AIR_CONDITION;

        protected override bool Hole => hole;
    }
}
