﻿namespace AquaShop.Models.Aquariums.Models
{
    public class SaltwaterAquarium : Aquarium
    {
        private const int CAPACITY = 25;
        public SaltwaterAquarium(string name) 
            : base(name, CAPACITY)
        {
        }
    }
}
