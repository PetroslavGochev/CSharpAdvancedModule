using FoodShortage.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Models
{
    public class Citizen : IBuy
    {
        public Citizen(string name,int age,string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }
        public string Id { get; set; }
        public string Birthdate { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }


}

