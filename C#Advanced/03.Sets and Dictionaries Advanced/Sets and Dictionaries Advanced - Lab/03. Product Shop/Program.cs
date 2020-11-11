using System;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string,double>> dict = new SortedDictionary<string, Dictionary<string,double>>();
            string input = string.Empty;
            while((input = Console.ReadLine()) != "Revision")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = data[0];
                string product = data[1];
                double price = double.Parse(data[2]);
                if (!dict.ContainsKey(shop))
                {
                    dict.Add(shop, new Dictionary<string, double>());
                }
                if (!dict[shop].ContainsKey(product))
                {
                    dict[shop].Add(product, price);
                }
                else
                {
                    dict[shop][product] = price;
                }   
            }
            foreach (var shop in dict)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
