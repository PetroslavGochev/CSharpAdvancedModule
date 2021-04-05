using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        private double overallPerformance;
        private decimal price;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
            
        }

        public IReadOnlyCollection<IComponent> Components 
            => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals
            => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                return this.overallPerformance;
            }
            protected set
            {
               if(this.components.Count == 0)
                {
                    this.overallPerformance = value;
                }
               else
                {
                    this.overallPerformance = this.components.Sum(x => x.OverallPerformance);
                }
            }
        }
        public override decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                this.price = value + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);
            }
        }

        public void AddComponent(IComponent component)
        {
            if(this.components.Any(x=>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {this.components.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {

           if(this.peripherals.Any(x=>x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.components.Where(x => x.GetType().Name == componentType).FirstOrDefault();
            if (component == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            this.components.Remove(component);
            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.peripherals.Where(x => x.GetType().Name == peripheralType).FirstOrDefault();
            if (peripheral == null)
            {
                throw new ArgumentException($"Component {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }
            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x=>x.OverallPerformance)}):");
            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
