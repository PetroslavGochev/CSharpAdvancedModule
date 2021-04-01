using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Presents.Tests
{
    public class Tests
    {
        private Present present;
        private Bag bag;
        [SetUp]
        public void Setup()
        {
            this.present = new Present("Test", 20.00);
            this.bag = new Bag();
        }

        [Test]
        public void BagCreateMethodAndGetPresent()
        {
            this.bag.Create(this.present);
            var expectedResult = this.bag.GetPresent("Test");
            Assert.AreEqual(expectedResult, this.present);
        }
        [Test]
        public void BagRemoveMethod()
        {
            var result = this.bag.Remove(this.present);
            var expectedResult = false;
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(null)]
        public void IfPresentDataIsInvalid(Present present)
        {
            if (present == null)
            {
                Assert.Throws<ArgumentNullException>(() => this.bag.Create(present));
            }
            present = new Present("Test", 20.00);

            this.bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => this.bag.Create(present));

        }
        [Test]
        public void GetPresentsCollection()
        {
            List<Present> presents = new List<Present>();
            presents.Add(this.present);
            this.bag.Create(this.present);
            var expectedResult = presents.AsReadOnly();
            Assert.AreEqual(expectedResult, this.bag.GetPresents());

        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            var expectedResult = new Present("Test", 20.00);
            this.bag.Create(this.present);
            this.bag.Create(new Present("Test1", 25.00));
            this.bag.Create(new Present("Test2", 30.00));
            var result = this.bag.GetPresentWithLeastMagic();
            Assert.AreEqual(expectedResult.Name, result.Name);
        }
    }
}