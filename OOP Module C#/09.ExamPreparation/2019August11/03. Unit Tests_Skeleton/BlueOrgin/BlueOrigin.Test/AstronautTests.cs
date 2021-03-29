using NUnit.Framework;

namespace BlueOrigin.Test
{   
    
    public class AstronautTests
    {
        private const string NAME = "PESHO";
        private const double OXYGEN = 10;

        private Astronaut astronaut;
        
        [SetUp]
        public void Setup()
        {

            this.astronaut = new Astronaut(NAME, OXYGEN);

        }
        [Test]
        public void TestIfAstronaultConstructorWorks()
        {
            var expectedName = this.astronaut.Name;
            var expectedOxyge = this.astronaut.OxygenInPercentage;
            Assert.AreEqual(expectedOxyge, 10);
            Assert.AreEqual(expectedName, "PESHO");           
        }
        [Test]
        //        public string Name { get;  }

        public void Dummy()
        {
            var expectedName = this.astronaut.Name;
            Assert.AreEqual(expectedName, "PESHO");
        }
    }
}
