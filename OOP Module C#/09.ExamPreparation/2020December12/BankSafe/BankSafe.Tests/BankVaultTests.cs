using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("Petroslav", "1234");
            this.bankVault = new BankVault();
            this.bankVault.AddItem("A1",this.item);
        }

        //ITEM TEST
        [Test]
        public void ItemConstructor()
        {
            Assert.IsNotNull(this.item);
        }

        [Test]
        public void PropertyOwnerItem()
        {
            var expectedNamd = "Petroslav";
            Assert.AreEqual(expectedNamd,this.item.Owner);
        }

        [Test]
        public void PropertyIdItem()
        {
            var expectedId = "1234";
            Assert.AreEqual(expectedId, this.item.ItemId);
        }


        //BANKVAULT TEST 
        [Test]
        public void BankVaultConstructor()
        {
            Assert.IsNotNull(this.bankVault);
        }
        [Test]
        public void PropertyWorked()
        {
            Assert.IsNotNull(this.bankVault.VaultCells);
        }

        //ADDMETHOD
        [TestCase("Doesnt Exist")]
        [TestCase("A1")]
        public void AddMethodIfDoesntContainsOrCellIsNotNull(string cell)
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem(cell, this.item));
        }

        [TestCase("A2")]
        public void AddExistItem(string cell)
        {
            Assert.Throws<InvalidOperationException>(() => this.bankVault.AddItem(cell, new Item("Petroslav","1234")));
        }


        //REMOVEMETHOD 
        [TestCase("Doesnt Exist")]
        [TestCase("A1")]
        public void RemoveMethodInvalidData(string cell)
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem(cell, new Item("Test","test")));
        }

        [Test]
        public void RemoveMethodWorked()
        {
            var expectedResult = "Remove item:1234 successfully!";
            Assert.AreEqual(expectedResult, this.bankVault.RemoveItem("A1", this.item));
        }

    }
}