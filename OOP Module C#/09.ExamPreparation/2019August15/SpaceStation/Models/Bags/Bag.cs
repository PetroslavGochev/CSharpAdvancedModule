using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Bags
{
    public class Bag : IBag
    {
        private  List<string> items;

        public Bag()
        {
            this.items = new List<string>(); 
        }
        public ICollection<string> Items => this.items;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if(this.items.Count == 0)
            {
                sb.AppendLine("none");
            }
            for (int i = 0; i < this.items.Count; i++)
            {
                if(i == this.items.Count - 1)
                {
                    sb.AppendLine($"{this.items[i]}");
                    continue;
                }
                sb.Append($"{this.items[i]}, ");              
            }
            return sb.ToString().TrimEnd();
        }
    }
}
