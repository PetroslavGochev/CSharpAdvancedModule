using ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree.Core
{
    public class Engine
    {
        private readonly ICollection<Person> people;
        private readonly ICollection<Product> products;
        public Engine()
        {
            this.people = new List<Person>();
            this.products = new List<Product>();
        }
        public void Run()
        {
            string[] people = ConsoleRead();
            string[] product = ConsoleRead();
            foreach (var item in people)
            {
                //try
                //{
                    AddPerson(item);
                //}
                //catch (ArgumentException ex)
                ////{
                //    Console.WriteLine(ex.Message);
                ////}
            }
            foreach (var item in product)
            {
                //try
                //{
                    AddProduct(item);
                //}
                //catch (ArgumentException ex)
                //{

                //    Console.WriteLine(ex.Message);
                //}
            }
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string nameOfPerson = data[0];
                string nameOfProduct = data[1];
                Person person = GetPerson(nameOfPerson);
                Product prod = GetProduct(nameOfProduct);
                if (person != null && prod != null)
                {
                    person.AddProduct(prod);
                }

            }
            foreach (var item in this.people)
            {
                Console.WriteLine(item);
            }
        }

        private string[] ConsoleRead() => Console.ReadLine()
            .Split(";", StringSplitOptions.RemoveEmptyEntries);

        private void AddPerson(string people)
        {
            string[] data = people.Split("=", StringSplitOptions.RemoveEmptyEntries);
            string personName = data[0];
            decimal money = decimal.Parse(data[1]);
            Person person = new Person(personName, money);
            this.people.Add(person);
        }
        private void AddProduct(string prodArr)
        {
            string[] data = prodArr.Split("=", StringSplitOptions.RemoveEmptyEntries);
            string productName = data[0];
            decimal cost = decimal.Parse(data[1]);
            Product product = new Product(productName, cost);
            this.products.Add(product);
        }
        private Person GetPerson(string name) => people.FirstOrDefault(x => x.Name == name);
        private Product GetProduct(string nameOfProduct) => products.FirstOrDefault(x => x.Name == nameOfProduct);
    }
}
