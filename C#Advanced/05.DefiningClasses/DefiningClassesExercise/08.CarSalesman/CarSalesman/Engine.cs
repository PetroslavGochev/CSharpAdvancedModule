using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        public Engine(string model,int power)
        {
            this.Model = model;
            this.Power = power;
            this.Efficiency = "n/a";
            this.Displacement = 0;
        }
        public Engine(string model, int power,int displacement,string efficiency)
            :this(model,power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}
