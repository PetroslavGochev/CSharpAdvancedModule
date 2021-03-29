namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private const string NAME = "APOLO";
        private const int CAPACITY = 10;
        private Spaceship spaceship;
        private Astronaut astronaut;

        [SetUp]
        public void Setup()
        {
            this.spaceship = new Spaceship(NAME, CAPACITY);
            this.astronaut = new Astronaut("Mitko", 10);
        }
        [Test]
        public void TestSpaceShipConstructor()
        {
            var expectedName = this.spaceship.Name;
            var capacity = this.spaceship.Capacity;
            Assert.AreEqual(capacity, 10);
            Assert.AreEqual(expectedName, "APOLO");
            Assert.That(this.spaceship.Count == 0);
        }
        [Test]
        [TestCase("", 10)]
        [TestCase(null, 10)]
        public void TestNameIsNullOrEmpty(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, capacity));
        }
        [Test]
        [TestCase("APOLO", -1)]
        public void TestNegativeCapacity(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Spaceship(name, capacity));
        }
        [Test]
        public void TestAddMethod()
        {
           this.spaceship = new Spaceship(NAME, 0);
            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astronaut));
        }
        [Test]
        public void TestAddMethodIfExist()
        {
            this.spaceship = new Spaceship(NAME, 2);
            this.spaceship.Add(this.astronaut);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.spaceship.Count);
            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(this.astronaut));
        }
        [Test]
        public void TestRemoveMethod()
        {
            this.spaceship.Add(this.astronaut);
            Assert.AreEqual(true,this.spaceship.Remove(this.astronaut.Name));
        }

    }
}