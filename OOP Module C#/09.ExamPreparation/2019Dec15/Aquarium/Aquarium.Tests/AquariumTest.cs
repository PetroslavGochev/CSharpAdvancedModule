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
            this.fish = new Fish("Petroslav");
            this.aquarium = new Aquarium("Aquarium", 1);
        }

        [Test]
        public void FishCtor()
        {
            Assert.IsNotNull(this.fish);
        }
        [Test]
        public void AquariumCtor()
        {
            Assert.IsNotNull(this.aquarium);
        }

        [Test]
        public void PropertyOfAquarium()
        {
            Assert.AreEqual("Aquarium",this.aquarium.Name);
        }
        [Test]
        public void PropertyOfAquariumCapacity()
        {
            Assert.AreEqual(1, this.aquarium.Capacity);
        }

          [Test]
        public void ZeroCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Petroslav", -1));
        }
        [Test]
        public void InvalidName()
        {
            string name = null;
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 2));
        }

        [Test]
        public void PropertyCount()
        {
            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void AddFishMethodInvalid()
        {
            this.aquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() => this.aquarium.Add(this.fish));
        }

        [Test]
        public void AddFishMethod()
        {
            this.aquarium.Add(this.fish);
            Assert.AreEqual(1, this.aquarium.Count);
        }

        [Test]
        public void RemoveInvalidFish()
        {
           
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Invalid"));
        }

        [Test]
        public void RemoveFish()
        {
            this.aquarium.Add(this.fish);
            this.aquarium.RemoveFish("Petroslav");
            Assert.AreEqual(0, this.aquarium.Count);

        }

        [Test]
        public void SellInvalidFish()
        {

            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Invalid"));
        }

        [Test]
        public void SellFish()
        {
            this.aquarium.Add(this.fish);
           Fish f = this.aquarium.SellFish("Petroslav");
            Assert.AreEqual(false, f.Available); ;

        }

        [Test]
        public void ReportMethod()
        {
            string expectedResult = $"Fish available at Aquarium: Petroslav";
            this.aquarium.Add(this.fish);
            Assert.AreEqual(expectedResult, this.aquarium.Report());

        }
    }
}