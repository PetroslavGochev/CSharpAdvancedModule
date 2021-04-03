using Aquariums;
using NUnit.Framework;
using System;

namespace Aquariums.Tests
{
    public class Tests
    {
        private Fish fish;
        private Aquarium aquarium;
        [SetUp]
        public void Setup()
        {
            this.fish = new Fish("Test");
            this.aquarium = new Aquarium("Aquarium", 1);
        }

        [Test]
        public void TestFishProperty()
        {
            Assert.AreEqual("Test", this.fish.Name);
            Assert.AreEqual(true, this.fish.Available);
        }
        [Test]
        public void TestAquariumProperty()
        {
            Assert.AreEqual("Aquarium", this.aquarium.Name);
            Assert.AreEqual(1, this.aquarium.Capacity);
            Assert.AreEqual(0, this.aquarium.Count);
        }
        [Test]
        public void TestPropertyIfDataIsInvalid()
        {
            Aquarium aquarium;
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(null, 1));
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(string.Empty, 1));
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("Test", -1));
        }

        [Test]
        public void TestAddMethod()
        {
            this.aquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(this.fish));
        }

        [Test]
        public void TestRemoveFishMethod()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.RemoveFish("Test");
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Test"));
        }

        [Test]
        public void TestSellFishMethod()
        {
            this.aquarium.Add(this.fish);
            bool expectedResult = false;
            Fish fish = this.aquarium.SellFish("Test");
            Assert.AreEqual(expectedResult, fish.Available);
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Test1"));
        }
        [Test]
        public void TestReport()
        {
            string expectedResult = $"Fish available at Aquarium: Test";
            this.aquarium.Add(this.fish);
            Assert.AreEqual(expectedResult, this.aquarium.Report());
        }
    }
}