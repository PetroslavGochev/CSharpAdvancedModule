﻿namespace Bakery.Models.BakedFoods.Models
{
    public class Cake : BakedFood
    {
        private const int PORTION = 245;

        public Cake(string name, decimal price) 
            : base(name, PORTION, price)
        {
        }
    }
}
