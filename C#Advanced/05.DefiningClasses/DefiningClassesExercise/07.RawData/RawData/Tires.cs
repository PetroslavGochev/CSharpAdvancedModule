using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Tires
    {
        public Tires(int age,double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }
        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
