using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Car
    {
        public Car(Engine engine,Cargo cargo,string model,Tires[] tire)
        {
            this.Cargo = cargo;
            this.Engine = engine;
            this.Model = model;
            this.Tire = tire;
        }
        public string Model { get; set; }
        public  Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tires[] Tire { get; set; }


    }
}
