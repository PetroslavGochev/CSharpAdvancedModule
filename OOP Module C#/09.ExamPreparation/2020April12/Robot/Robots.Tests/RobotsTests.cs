namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void Setup()
        {
            this.robot = new Robot("Test", 50);
            this.robotManager = new RobotManager(1);
            this.robotManager.Add(this.robot);
        }
         
        [Test]
        public void PropertyOfRobotClass()
        {
            var expectedResult = this.robot.MaximumBattery;
            Assert.AreEqual(expectedResult, 50);
        }

        [Test]
        public void PropertyRobotManager()
        {
            var expectedResult = this.robotManager.Count;
            var expectedCapacity = this.robotManager.Capacity;
            Assert.AreEqual(expectedResult, 1);
            Assert.AreEqual(expectedCapacity, 1);
        }
        [Test]
        public void RemoveMethodWorked()
        {
            var expectedResult = 0;
            this.robotManager.Remove("Test");
            Assert.AreEqual(expectedResult,this.robotManager.Count);
        }
        [Test]
        public void WorkMethod()
        {
            var expectedResult = 40;
            this.robotManager.Work("Test","Test",10);
            Assert.AreEqual(expectedResult, this.robot.Battery);
        }
        [Test]
        public void ChargeMethod()
        {
            var expectedResult = 50;
            this.robotManager.Charge("Test");
            Assert.AreEqual(expectedResult, this.robot.Battery);
        }

        [Test]
        public void InvalidCommand()
        {
            Assert.Throws<ArgumentException>(() => this.robotManager = new RobotManager(-1));
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(this.robot));
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(new Robot("Invalid",50)));
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove("Invalid"));
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Invalid","Invalid",20));
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Test","Test",60));
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge("Invalid"));

        }

    } 
}
