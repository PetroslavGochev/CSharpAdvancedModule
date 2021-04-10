using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish.Models
{
    public class SaltwaterFish : Fish
    {
        private const int INITIAL_SIZE = 5;
        public SaltwaterFish(string name, string species, decimal price) 
            : base(name, species, price)
        {
            this.Size = 5;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
