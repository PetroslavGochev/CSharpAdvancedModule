using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar unitCar;
        private UnitDriver unitDriver;
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.unitCar = new UnitCar("Peugeot", 100, 1600);
            this.unitDriver = new UnitDriver("Petroslav", unitCar);
            this.raceEntry = new RaceEntry();
        }

        //UNIT CARR
        [Test]
        public void UnitCarCreate()
        {
            Assert.IsNotNull(this.unitCar);
        }
        [Test]
        public void UnitCarPropertyWorkedCorectly()
        {
            var expectedModel = "Peugeot";
            var hP = 100;
            var cM = 1600;
            Assert.AreEqual(expectedModel, this.unitCar.Model);
            Assert.AreEqual(hP, this.unitCar.HorsePower);
            Assert.AreEqual(cM, this.unitCar.CubicCentimeters);
        }

        //UNITDRIVER
        [Test]
        public void UnitDriverCtor()
        {
            Assert.IsNotNull(this.unitDriver);
        }
        [Test]
        public void UnitDriverPropertyCar()
        {
            Assert.IsNotNull(this.unitDriver.Car);
        }
        [Test]
        public void UnitDriverPropertyName()
        {
            Assert.AreEqual("Petroslav",this.unitDriver.Name);
        }
        [Test]
        public void UnitDriverPropertyIfNameIsInvalid()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null,this.unitCar));
        }


        //RaceEntry
        [Test]
        public void RaceEntryCtor()
        {
            Assert.IsNotNull(this.raceEntry);
        }
        [Test]
        public void PropertyCounter()
        {
            Assert.AreEqual(0,this.raceEntry.Counter);
        }
        [Test]
        public void AddMethodCorectly()
        {
            string expectedResult = "Driver Petroslav added in race.";
            string result = this.raceEntry.AddDriver(this.unitDriver);
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void AddMethodWithInvalidDriver()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }
        [Test]
        public void AddMethodIfDriverExist()
        {
            this.raceEntry.AddDriver(this.unitDriver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(this.unitDriver));
        }
        [Test]
        public void CalculateMethod()
        {
            UnitCar rosenCar = new UnitCar("Honda", 100, 1600);
            UnitDriver rosen = new UnitDriver("Rosen", rosenCar);

            UnitCar ivanCar = new UnitCar("BMW", 100, 2000);
            UnitDriver ivan = new UnitDriver("Ivan", ivanCar);

            
            this.raceEntry.AddDriver(this.unitDriver);
            this.raceEntry.AddDriver(rosen);
            this.raceEntry.AddDriver(ivan);

            Assert.AreEqual(100, this.raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateMethodIfDriverIsLessThan2()
        {
         

            this.raceEntry.AddDriver(this.unitDriver);


            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }


    }
}