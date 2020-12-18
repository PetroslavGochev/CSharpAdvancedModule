using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Common
{
    public static class Modifiers
    {
        public static Dictionary<string, double> Modifier = new Dictionary<string, double>()
        {
            { "white",1.5 },
            { "wholegrain",1.0 },
            { "crispy",0.9 },
            { "chewy",1.1},
            { "homemade",1.0 },
            { "meat",1.2 },
            { "veggies",0.8 },
            { "cheese",1.1},
            { "sauce",0.9 }
        };
    }
}
