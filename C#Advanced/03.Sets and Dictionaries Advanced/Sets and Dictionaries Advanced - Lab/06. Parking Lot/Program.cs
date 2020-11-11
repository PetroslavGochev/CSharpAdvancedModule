using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            HashSet<string> carNumber = new HashSet<string>();
            while((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                if(data[0] == "IN")
                {
                    carNumber.Add(data[1]);
                    continue;
                }
                if (carNumber.Contains(data[1]))
                {
                    carNumber.Remove(data[1]);
                }
            }
            if (!carNumber.Any())
            {
                Console.WriteLine($"Parking Lot is Empty");
                return;
            }
            Console.WriteLine(string.Join(Environment.NewLine, carNumber));
        }
    }
}
