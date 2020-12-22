using BirthdayCelebration.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebration.Models
{
    class Pet:IBirthday
    {
        public Pet(string name,string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Name { get; set; }
        public string Birthdate { get; set; }
        public override string ToString() => $"{this.Birthdate}";
        
    }
}
