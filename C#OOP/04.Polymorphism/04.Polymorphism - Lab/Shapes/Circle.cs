using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private const double VALUE = 2.00;
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double CalculateArea() => Math.PI * Math.Pow(radius, VALUE);
        

        public override double CalculatePerimeter() => VALUE * Math.PI* radius;

        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}
