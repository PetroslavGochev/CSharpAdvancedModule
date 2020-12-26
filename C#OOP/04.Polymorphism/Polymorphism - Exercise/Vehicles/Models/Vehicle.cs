using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Common;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private const double PROBLEM = 0.95;
        public Vehicle(double fuelQuantity, double fuelConsumtpion)
        {
            this.FuelConsumption = fuelConsumtpion;
            this.FuelQuantity = fuelQuantity;
        }
        protected double FuelQuantity { get; private set; }
        protected double FuelConsumption { get; }
        protected abstract double AirCondition { get; }
        protected abstract bool Hole { get; }

        public virtual void Driving(double distance)
        {
            double distanceWithFuel = distance * (this.FuelConsumption + AirCondition);
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
        public virtual void Refueling(double liters)
        {
            if (Hole)
            {
                this.FuelQuantity += liters * PROBLEM;
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }

        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:f2}";

    }
}
