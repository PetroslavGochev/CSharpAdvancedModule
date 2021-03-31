using MXGP.Models.Motorcycles.Contracts;
using System;

namespace MXGP.Models.Motorcycles.Models
{
    public abstract class Motorcycle : IMotorcycle
    {
        private int minimumHorsePower;
        private int maximumHorsePower;
        private string model;
        private int horsePower;

        private Motorcycle()
        {
            if (this.GetType().Name == "SpeedMotorcycle")
            {
                this.minimumHorsePower = 50;
                this.maximumHorsePower = 69;
            }
            else if (this.GetType().Name == "PowerMotorcycle")
            {
                this.minimumHorsePower = 70;
                this.maximumHorsePower = 100;
            }
        }
        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
            : this()
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {value} cannot be less than 4 symbols.");
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {

                if (value < this.minimumHorsePower || value > this.maximumHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.horsePower * laps;
        }
    }
}
