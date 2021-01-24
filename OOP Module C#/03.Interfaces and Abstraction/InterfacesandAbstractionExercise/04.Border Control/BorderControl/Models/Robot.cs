using BorderControl.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Robot:IId
    {
        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; set; }
        public string Id { get; set; }
        public override string ToString() => $"{this.Id}";
        
    }
}
