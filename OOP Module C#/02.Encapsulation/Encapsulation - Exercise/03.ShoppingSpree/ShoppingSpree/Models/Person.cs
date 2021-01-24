using ShoppingSpree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Person
    {
        private const string NOT_BUY_PRODUCT = "{0} can't afford {1}";
        private const string BUY_PRODUCT = "{0} bought {1}";
        private const string NOTHING = "Nothing bought";
        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        private Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money)
            : this()
        {
            this.Money = money;
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExcMsg);
                }
                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.MoneyNegativeExcMsg);
                }
                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Bag
        {
            get => (IReadOnlyCollection<Product>)this.bag;
        }

        private bool IsBagIsEmpty() => this.Bag.Count == 0;
        public void AddProduct(Product product)
        {
            if (this.Money >= product.Cost)
            {
                this.Money -= product.Cost;
                this.bag.Add(product);
                Console.WriteLine(BUY_PRODUCT, this.Name, product.Name);
            }
            else
            {
                Console.WriteLine(NOT_BUY_PRODUCT, this.Name, product.Name);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (IsBagIsEmpty())
            {
                sb.Append($"{this.name} - {NOTHING}");
            }
            else
            {
                sb.AppendLine($"{this.Name} - {string.Join(", ", this.Bag)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
