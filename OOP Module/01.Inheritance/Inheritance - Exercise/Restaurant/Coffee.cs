using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double CoffeMililiters = 50;
        private const decimal CoffeePrice  = 3.50M;

        public Coffee(string name,double caffeine) : base(name, CoffeePrice,CoffeMililiters)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
