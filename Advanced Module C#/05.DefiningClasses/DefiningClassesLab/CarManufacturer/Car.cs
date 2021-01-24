using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
   public class Car
    {
        private Tire[] tires;
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;

        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make,string model,int year,double fuelQuantity, double fuelConsumption)
            :this(make,model,year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine engine,Tire[] tires)
            :this(make,model,year,fuelQuantity,fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires
        {
            get => tires;
            set
            {
                if (value.Length >= 0 && value.Length <= 4)
                    tires = value;
            }
        }

        public void Drive(double distance)
        {
            double consumption = distance  * FuelConsumption / 100;
            if (this.FuelQuantity - consumption <= 0)
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
            else
            {
                this.FuelQuantity -= consumption;
            }
        }
        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {FuelQuantity}");
            return result.ToString().Trim();
        }
    }
}
