using NUnit.Framework;
using System;

namespace Telecom.Tests
{
    public class Tests
    {
        private Phone phone;
        [SetUp]
        public void Setup()
        {
            this.phone = new Phone("Nokia", "6300");
        }

        [TestCase(null,"6300")]
        [TestCase("","6300")]
        [TestCase("Nokia",null)]
        [TestCase("Nokia","")]
        public void IfDataAreInvalid(string make,string model)
        {
            Assert.Throws<ArgumentException>(() => new Phone(make, model));
        }
        [Test]
        public void IfPropertyWorkAndAddMethod()
        {
            this.phone.AddContact("Test", "Test");
            Assert.AreEqual(1, this.phone.Count);
            Assert.AreEqual("Nokia", this.phone.Make);
            Assert.AreEqual("6300", this.phone.Model);
        }
        [Test]
        public void IfCallMethodWork()
        {
            this.phone.AddContact("Test", "Test");
            string expectedResult = $"Calling {"Test"} - {"Test"}...";
            Assert.AreEqual(expectedResult, this.phone.Call("Test"));
        }

        [TestCase("Test","Test")]
        public void AddMethodExceptionIfDataAreInvalid(string name,string number)
        {
            this.phone.AddContact("Test", "Test");
            Assert.Throws<InvalidOperationException>(() => this.phone.AddContact(name,number));
        }
        [TestCase("Test")]
        public void CallMethodExceptionIfDataAreInvalid(string name)
        {
            Assert.Throws<InvalidOperationException>(() => this.phone.Call(name));
        }

    }
}