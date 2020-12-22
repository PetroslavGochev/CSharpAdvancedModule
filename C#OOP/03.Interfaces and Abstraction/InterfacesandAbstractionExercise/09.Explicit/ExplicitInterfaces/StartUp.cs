using ExplicitInterfaces.Contracts;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            while((input = Console.ReadLine()) != "End")
            {
                var data = input.Split();
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);
                Citizen citizen = new Citizen(name,country,age);
                Console.WriteLine(((IPerson)citizen).GetName());
                Console.WriteLine(((IResident)citizen).GetName());
            }
        }
    }
}
