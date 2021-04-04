namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        private Part part;
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            this.part = new Part("Test", 25M);
            this.computer = new Computer("HP");
        }

        [Test]
        public void PartConstructor()
        {
            Assert.That(this.part != null);
        }

        [Test]
        public void ComputerProperty()
        {
            Assert.AreEqual("HP", this.computer.Name);
        }

        [Test]
        public void ComputerInvalidData()
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(string.Empty));
            Assert.Throws<InvalidOperationException>(() => this.computer.AddPart(null));
        }
        [Test]
        public void ComputerAddMethod()
        {
            this.computer.AddPart(this.part);
            Assert.AreEqual(1, this.computer.Parts.Count);
        }
        [Test]
        public void ComputerTotalSum()
        {
            this.computer.AddPart(this.part);
            Assert.AreEqual(25,this.computer.TotalPrice);
        }
        [Test]
        public void GetPartMethod()
        {
            this.computer.AddPart(this.part);
            Assert.That(null != this.computer.GetPart("Test"));
        }
        [Test]
        public void RemovePartMethod()
        {
            this.computer.AddPart(this.part);
            Assert.AreEqual(true, this.computer.RemovePart(this.part));
        }

    }
}