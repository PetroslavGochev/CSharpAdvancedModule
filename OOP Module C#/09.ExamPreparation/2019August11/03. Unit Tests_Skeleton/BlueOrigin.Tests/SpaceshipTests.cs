namespace BlueOrigin.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship spaceship;

        private Astronaut mainAstronaut = new Astronaut("John", 10);
        private Astronaut secondAstronaut = new Astronaut("Ben", 15);
        [SetUp]
        public void Setup()
        {
            spaceship = new Spaceship("BattleStar", 2);
           

        }
        [Test]
        public void TestIfAstronaultConstructorWorks()
        {

            Astronaut astronaut = new Astronaut("Ben", 10);
            Assert.That(astronaut.Name == "Ben");
            Assert.That(astronaut.OxygenInPercentage == 10);

        }
        [Test]
        public void TestIfSpaceshipConstructor()
        {

            spaceship.Add(mainAstronaut);
            Assert.That(spaceship.Count > 0);
        }
        [Test]
        public void WhenCapacityIsNEgativeShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship("Galaxy", -1));
        }
        [TestCase(null)]
        [TestCase("")]
        public void SpaceshipNameShouldThrowExceptionIfIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>  new Spaceship(name, 10));
           
        }
        [Test]
        public void AddShouldThrowExceptionIfCapacityIsFull()
        {
            spaceship.Add(mainAstronaut);
            spaceship.Add(secondAstronaut);
            
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(new Astronaut(null,10)));
        }
        [Test]
        public void AddShouldThrowExceptionIfAstronaultAlredyExists()
        {
            spaceship.Add(mainAstronaut);
            Assert.Throws<InvalidOperationException>(() => spaceship.Add(mainAstronaut));
        }
        [Test]
        public void TestIfRemoveWorks()
        {
            spaceship.Add(mainAstronaut);

            Assert.AreEqual(true,spaceship.Remove("John"));
        }



    }
}