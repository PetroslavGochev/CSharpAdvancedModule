using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private const string COMPUTER_DOESNT_EXIST = "Computer with this id does not exist.";

        private List<IComputer> computers;
        public Controller()
        {
            this.computers = new List<IComputer>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            ComponentType cT = new ComponentType();
            IComponent component = null; ;
            if (IsComputerExistInCollection(computerId))
            {
                throw new ArgumentException(COMPUTER_DOESNT_EXIST);
            }
            else if(this.computers.Where(x=>x.Id == computerId).Any(x=>x.Components.Any(x=>x.Id == id)))
            {
                throw new ArgumentException("Component with this id already exists.");
            }
            else if(!Enum.TryParse<ComponentType>(componentType,out cT))
            {
                throw new ArgumentException("Component type is invalid.");
            }
            else if(cT == ComponentType.CentralProcessingUnit)
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (cT == ComponentType.Motherboard)
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (cT == ComponentType.PowerSupply)
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (cT == ComponentType.RandomAccessMemory)
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (cT == ComponentType.SolidStateDrive)
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (cT == ComponentType.VideoCard)
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            IComputer computer = this.computers.Where(x => x.Id == computerId).FirstOrDefault();
            computer.AddComponent(component);
            return $"Component {component.GetType().Name} with id {component.Id} added successfully in computer with id {computer.Id}.";
        }    

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;
            if (this.computers.Any(x => x.Id == id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }
            else if (computerType != "DesktopComputer" && computerType != "Laptop")
            {
                throw new ArgumentException("Computer type is invalid.");
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            this.computers.Add(computer);
            return $"Computer with id {computer.Id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            PeripheralType pT = new PeripheralType();
            IPeripheral peripheral = null;
            if (IsComputerExistInCollection(computerId))
            {
                throw new ArgumentException(COMPUTER_DOESNT_EXIST);
            }
            else if(this.computers.Where(x=>x.Id == computerId).Any(x=>x.Peripherals.Any(x=>x.Id == id)))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }
            else if(!Enum.TryParse<PeripheralType>(peripheralType,out pT))
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            else if(pT == PeripheralType.Headset)
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (pT == PeripheralType.Keyboard)
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (pT == PeripheralType.Monitor)
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (pT == PeripheralType.Mouse)
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            this.computers.Where(x => x.Id == computerId).FirstOrDefault().AddPeripheral(peripheral);
            return $"Peripheral {peripheral.GetType().Name} with id {peripheral.Id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            IComputer computer = this.computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();
            if(computer == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            if (IsComputerExistInCollection(id))
            {
                throw new ArgumentException(COMPUTER_DOESNT_EXIST);
            }
            IComputer computer = this.computers.Where(x => x.Id == id).FirstOrDefault();
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (IsComputerExistInCollection(id))
            {
                throw new ArgumentException(COMPUTER_DOESNT_EXIST);
            }
            return this.computers.Where(x => x.Id == id).FirstOrDefault().ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (IsComputerExistInCollection(computerId))
            {
                throw new ArgumentException(COMPUTER_DOESNT_EXIST);
            }
            IComponent component = this.computers.Where(x => x.Id == computerId).FirstOrDefault().RemoveComponent(componentType);
            if(component == null)
            {
                return null;
            }

            return $"Successfully removed {component.GetType().Name} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (IsComputerExistInCollection(computerId))
            {
                throw new ArgumentException(COMPUTER_DOESNT_EXIST);
            }
            IPeripheral peripheral = this.computers.Where(x => x.Id == computerId).FirstOrDefault().RemovePeripheral(peripheralType);
            if (peripheral == null)
            {
                return null;
            }
            return $"Successfully removed {peripheral.GetType().Name} with id { peripheral.Id}.";
        }

        private bool IsComputerExistInCollection(int computerId)
        {
            return !this.computers.Any(x => x.Id == computerId);
        }

    }
}
