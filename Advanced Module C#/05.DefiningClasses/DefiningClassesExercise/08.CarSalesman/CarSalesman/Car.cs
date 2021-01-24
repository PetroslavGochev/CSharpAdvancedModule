using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Car
    {
        public Car(string model,Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = 0;
            this.Color = "n/a";
        }
        public Car(string model, Engine engine, int weight, string color)
            :this(model,engine)
        {
            this.Weight = weight;
            this.Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            bool flag = this.Weight == 0;
            bool flagEngine = this.Engine.Displacement == 0;
            result.AppendLine($"{Model}:");
            result.AppendLine($"  {Engine.Model}:");
            result.AppendLine($"   Power: {Engine.Power}");
            result.AppendLine(flagEngine ? "   Displacement: n/a" : $"   Displacement: {Engine.Displacement}");
            result.AppendLine($"   Efficiency: {Engine.Efficiency}");
            result.AppendLine(flag ? $"  Weight: n/a" : $"  Weight: {Weight}");
            result.Append($"  Color: {Color}");
            return result.ToString();
        }
    }
}
