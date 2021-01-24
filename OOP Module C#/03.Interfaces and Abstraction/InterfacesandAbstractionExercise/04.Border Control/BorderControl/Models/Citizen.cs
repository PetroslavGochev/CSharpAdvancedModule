using BorderControl.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Citizen:IId
    {
        public Citizen(string name,int age,string id)
        {
            this.Name = name;
            this.Id = id;
            this.Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public override string ToString() => $"{this.Id}";
    }
}
