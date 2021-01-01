using System;
using System.Collections.Generic;
using System.Text;
using VehiclesExtension.Common;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle
    {
        private const double PROBLEM = 0.95;
        public Vehicle(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        protected double FuelQuantity { get; private set; }
        protected double FuelConsumption { get; }
        protected abstract double AirCondition { get;  }
        protected abstract bool Hole { get;  }
        protected double TankCapacity { get; }
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
    }
}
