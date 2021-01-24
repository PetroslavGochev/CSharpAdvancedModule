using FoodShortage.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
   public class Rebel:IBuy
    {

        public Rebel(string name,int age,string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
            this.Food = 0;
        }
        public string Group { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }
        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
