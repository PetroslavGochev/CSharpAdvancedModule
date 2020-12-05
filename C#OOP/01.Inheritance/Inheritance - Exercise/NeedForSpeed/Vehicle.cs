using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumtpion = 1.25;
        public Vehicle(int horsePower,double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            
        }
        public virtual double FuelConsumption => DefaultFuelConsumtpion;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public  virtual void Drive(double kilometers)
        {
            double distance = this.Fuel - this.FuelConsumption * kilometers;
            if(distance >= 0)
            {
                this.Fuel = distance;
            }
        }
    }
}
