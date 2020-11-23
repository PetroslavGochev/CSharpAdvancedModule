using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.Place = new List<Car>();
        }
        public List<Car> Place { get; set; }
        public int Count => this.Place.Count;
        public string AddCar(Car car)
        {
            if (Place.Any(x=>x.RegistrationNumber == car.RegistrationNumber))    
            {
                return $"Car with that registration number, already exists!";
            }
            else if (Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Place.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            bool isExist = Place.Any(x => x.RegistrationNumber == registrationNumber);
            if (!isExist)
            {
                return $"Car with that registration number, doesn't exist!";
            }
            else
            {
                Place.Remove(this.Place.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return Place.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }
        public  void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var registration in RegistrationNumbers)
            {
                this.Place.RemoveAll(x => x.RegistrationNumber == registration);
            }
        }
    }
}
