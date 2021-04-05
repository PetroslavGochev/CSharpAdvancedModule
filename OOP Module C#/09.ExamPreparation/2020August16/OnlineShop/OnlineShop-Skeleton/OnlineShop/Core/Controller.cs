using OnlineShop.Models.Products.Computers;
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
            if (IsComputerExistInCollection(computerId))
            {

            }
        }

        private bool IsComputerExistInCollection(int computerId)
        {
            return !this.computers.Any(x => x.Id == computerId);
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
            throw new System.NotImplementedException();
        }

        public string BuyBest(decimal budget)
        {
            throw new System.NotImplementedException();
        }

        public string BuyComputer(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetComputerData(int id)
        {
            throw new System.NotImplementedException();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            throw new System.NotImplementedException();
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            throw new System.NotImplementedException();
        }

    }
}
