using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private ICollection<Pet> data;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.data = new List<Pet>();
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if (this.data.Count < this.Capacity)
            {
                data.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            var pet = this.data.Where(x => x.Name.Contains(name)).FirstOrDefault();
            if (pet != null)
            {
                this.data.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
            => this.data
            .Where(x => x.Name == name && x.Owner == owner)
            .FirstOrDefault();
        public Pet GetOldestPet()
            => this.data
            .Where(x=>x.Age == this.data.Max(x=>x.Age))
            .FirstOrDefault();
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var p in this.data)
            {
                sb.AppendLine($"Pet {p.Name} with owner: {p.Owner}");
            }
            return sb.ToString().TrimEnd();
        }


    }
}
