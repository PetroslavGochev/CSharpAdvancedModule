using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width,double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get
            {
                return this.length;
            }
             private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }
             private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public void SurfaceArea()
        {
            double surfArea = (2 * this.Length * this.Width) + (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            Console.WriteLine($"Surface Area - {surfArea:F2}");
        }
        public void LateralSurfaceArea()
        {
            double lateral = (2 * this.Length * this.Height) + (2 * this.Width * this.Height);
            Console.WriteLine($"Lateral Surface Area - {lateral:F2}");
        }
        public void Volume()
        {
            double volume = this.Length * this.Height * this.Width;
            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}
