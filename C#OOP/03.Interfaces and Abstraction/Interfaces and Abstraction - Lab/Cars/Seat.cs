using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    class Seat:ICar
    {
        public Seat(string model,string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{this.Color} Seat {this.Model}";
        }
    }
}
