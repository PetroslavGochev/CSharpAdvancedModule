using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private const double PERIMETER = 2.00;
        private double height;
        private double width;
        public Rectangle(double height,double width)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateArea() => this.width * this.height;
        

        public override double CalculatePerimeter() => (this.width + this.height)*PERIMETER;
        
        public override string Draw()
        {
            return $"{base.Draw()} {this.GetType().Name}";
        }
    }
}
