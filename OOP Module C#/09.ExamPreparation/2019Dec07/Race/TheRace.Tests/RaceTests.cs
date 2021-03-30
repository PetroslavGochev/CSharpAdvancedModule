using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class Tests
    {
        RaceEntry raceEntry;
        UnitRider unitRider;
        UnitMotorcycle unitMotorcycle;
        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.unitMotorcycle = new UnitMotorcycle("Test", 200, 20);
            this.unitRider = new UnitRider("Test", this.unitMotorcycle);
            this.raceEntry.AddRider(unitRider);
        }

        [Test]
        public void MotorcycleAndUnitRiderPropertyTest()
        {
            string expectedName = "Test";
            int expectedHorsePower = 200;
            int expectedCubicCm = 20;
            string expectedUnitRiderName = "Test";
            UnitMotorcycle expectMotorcycle = new UnitMotorcycle("Test", 200, 20);
            Assert.AreEqual(expectedName, this.unitMotorcycle.Model);
            Assert.AreEqual(expectedHorsePower, this.unitMotorcycle.HorsePower);
            Assert.AreEqual(expectedCubicCm, this.unitMotorcycle.CubicCentimeters);
            Assert.AreEqual(expectedUnitRiderName, this.unitRider.Name);
            Assert.AreEqual(expectMotorcycle.Model, this.unitRider.Motorcycle.Model);
        }

        [Test]
        public void RaceAddMethodIfRiderIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(null));
        }

        [Test]
        public void RaceAddMethodIfRiderAlreadtExist()
        {
            UnitMotorcycle uM = new UnitMotorcycle("Test", 200, 20);
            UnitRider uR = new UnitRider("Test", uM);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(uR));
        }


        [Test]
        public void RaceEntryProperty()
        {
            Assert.AreEqual(1, this.raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageMethodIfCollectionIsEmpty()
        {

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageMethod()
        {
            UnitMotorcycle uM = new UnitMotorcycle("Test1", 200, 20);
            UnitRider uR = new UnitRider("Test1", uM);
            this.raceEntry.AddRider(uR);
            Assert.AreEqual(200, this.raceEntry.CalculateAverageHorsePower());
        }
    }
}