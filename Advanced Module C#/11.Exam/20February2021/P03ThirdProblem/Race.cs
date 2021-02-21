using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private ICollection<Racer> data;
        public Race(string name,int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Racer>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Racer Racer)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            return this.data
                .Remove(this.data.Where(x => x.Name == name)
                .FirstOrDefault());
        }
        public Racer GetOldestRacer()
        {
            return this.data.Where(x => x.Age == this.data.Max(x => x.Age)).FirstOrDefault();
        }
        public Racer GetRacer(string name)
        {
            return this.data.Where(x => x.Name == name).FirstOrDefault();
        }
        public Racer GetFastestRacer()
            => this.data.Where(x => x.Car.Speed == this.data.Max(x => x.Car.Speed)).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Racers participating at {this.Name}:");
            foreach (var item in this.data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
            

    }
}
