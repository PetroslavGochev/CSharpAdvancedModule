using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Frog : Animals
    {
        public Frog(string name, int age, string gender) : base(name, age, gender)
        {

        }
        public override string ProduceSound() => "Ribbit";
    }
}
