using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();
            for (int i = 0; i < number; i++)
            {
                double text = double.Parse(Console.ReadLine());
                list.Add(text);
            }
            double compare = double.Parse(Console.ReadLine());
            Console.WriteLine(Box<double>.Return(compare, list));
        }
    }
}

