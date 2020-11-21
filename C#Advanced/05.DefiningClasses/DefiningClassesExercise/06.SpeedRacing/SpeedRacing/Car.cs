using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    class Car
    {
        public Car(string model,double fuelAmount,double fuelConsumpt)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumpt;
            this.TravelledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Travel(double distance)
        {
            var calc = distance * this.FuelConsumptionPerKilometer;
            if(calc > this.FuelAmount)
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
            else
            {
                this.TravelledDistance += distance;
                this.FuelAmount -= calc;
            }
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{Model} {FuelAmount:f2} {TravelledDistance}");
            return result.ToString(); 
        }
    }
}
