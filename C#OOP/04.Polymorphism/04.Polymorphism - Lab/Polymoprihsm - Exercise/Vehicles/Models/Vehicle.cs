using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {

        public Vehicle(double fuelQuantity, double fuelConsumtpion)
        {
            this.FuelConsumption = fuelConsumtpion;
            this.FuelQuantity = fuelQuantity;
        }
        protected double FuelQuantity { get;  set; }
        protected double FuelConsumption { get;  set; }

        public abstract void Driving(double distance);
        public abstract void Refueling(double liters);
        public  override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity}";

    }
}
