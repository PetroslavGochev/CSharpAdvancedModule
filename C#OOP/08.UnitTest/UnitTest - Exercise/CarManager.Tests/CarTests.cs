using NUnit.Framework;

namespace Tests
{
    using CarManager;
    public class CarTests
    {
        private const string MAKE = "Test";
        private const string MODEL = "Audi";
        private const double FUEL_CONSUMTPION = 5.00;
        private const double FUEL_CAPACITY = 200.00;
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car(MAKE, MODEL, FUEL_CONSUMTPION, FUEL_CAPACITY);
        }
        [Test]
        public void ConstructorWorkCoretly()
        {
            Assert.IsNotNull(car);
        }
        //Test Properties
        [Test]
        [TestCase(null, MAKE, FUEL_CONSUMTPION, FUEL_CAPACITY)]
        [TestCase("", MAKE, FUEL_CONSUMTPION, FUEL_CAPACITY)]
        [TestCase(MODEL, null, FUEL_CONSUMTPION, FUEL_CAPACITY)]
        [TestCase(MODEL, "", FUEL_CONSUMTPION, FUEL_CAPACITY)]
        [TestCase(MODEL, MAKE, 0, FUEL_CAPACITY)]
        [TestCase(MODEL, MAKE, -1, FUEL_CAPACITY)]
        [TestCase(MODEL, MAKE, FUEL_CONSUMTPION, 0)]
        [TestCase(MODEL, MAKE, FUEL_CONSUMTPION, -1)]

        public void IfAnyPropertiesIsInvalid(
             string make,
             string model,
             double fuelConsumption,
             double fuelCapacity)
        {
            Assert.That(() => new Car(make, model, fuelConsumption, fuelCapacity), Throws.ArgumentException);

        }
        [Test]
        public void IfFueLAmountIsValid()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void IfRefuelIsNegative(double refuel)
        {
            Assert.That(() => car.Refuel(refuel), Throws.ArgumentException);

        }
        [Test]
        [TestCase(50)]

        public void IfRefuelIsValid(double refuel)
        {
            double expectedResult = refuel;
            car.Refuel(refuel);
            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
        [Test]
        [TestCase(300)]

        public void IfRefuelIsMoreThanCapacity(double refuel)
        {
            double expectedResult = 200;
            car.Refuel(refuel);
            Assert.AreEqual(expectedResult, car.FuelAmount);

        }
        [Test]
        [TestCase(5)]
        public void DistanceIsCorectly(double distance)
        {
            car.Refuel(50);
            double fuelNeeded = (distance / 100) * FUEL_CONSUMTPION;
            double expectedResult = car.FuelAmount - fuelNeeded;
            car.Drive(distance);
            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
        [Test]
        [TestCase(1000)]
        public void DistanceIsMoreThanFuel(double distance)
        {
            Assert.That(() => this.car.Drive(distance), Throws.InvalidOperationException);
        }

    }
}