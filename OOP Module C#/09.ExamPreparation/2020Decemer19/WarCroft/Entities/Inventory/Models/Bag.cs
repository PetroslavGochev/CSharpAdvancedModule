using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Models
{
    public abstract class Bag : IBag
    {
        private const int CAPACITY = 100;
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load 
            => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
            => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            else if(!this.Items.Any(x=>x.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            Item item = this.Items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
