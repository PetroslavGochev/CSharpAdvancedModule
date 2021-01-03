using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.Common;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITION = 1.4;
        private const bool HOLE = false;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        protected override double AirCondition => AIR_CONDITION;

        protected override bool Hole => HOLE;
        public void EmptyBus(double distance)
        {
            double distanceWithFuel = distance * this.FuelConsumption;
            if (distanceWithFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= distanceWithFuel;
                Console.WriteLine(String.Format(GlobalConstants.TRAVELED_DISTANCE, GetType().Name, distance));
            }
            else
            {
                Console.WriteLine(String.Format(GlobalConstants.NEED_REFUELING, GetType().Name));
            }
        }
    }
}
