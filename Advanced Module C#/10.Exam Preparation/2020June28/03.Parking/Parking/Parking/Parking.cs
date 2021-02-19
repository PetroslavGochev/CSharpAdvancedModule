using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private ICollection<Car> data;
        public Parking(string type,int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if(this.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            var car = this.data
                .Where(x => x.Manufacturer == manufacturer && x.Model == model)
                .FirstOrDefault();
            if(car != null)
            {
                return this.data.Remove(car);
            }
            return false;
        }

        public Car GetLatestCar()
            => this.data
            .Where(x => x.Year == this.data.Max(x => x.Year))
            .FirstOrDefault();
        public Car GetCar(string manufacturer, string model)
            => this.data
            .Where(x => x.Manufacturer == manufacturer && x.Model == model)
            .FirstOrDefault();

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            foreach (Car car in this.data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
