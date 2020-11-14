using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] number = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(x => x * 1.20)
                .ToArray();
            foreach (var item in number)
            {
                Console.WriteLine($"{item:f2}");
            }
                
        }
    }
}
