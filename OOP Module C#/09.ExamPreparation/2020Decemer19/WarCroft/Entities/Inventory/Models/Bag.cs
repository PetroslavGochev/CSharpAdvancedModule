using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Models
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; } = 100;

        public int Load 
            => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items
            => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.Items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            else if(!this.Items.Any(x=>x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag),name);
            }
            Item item = this.Items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}
