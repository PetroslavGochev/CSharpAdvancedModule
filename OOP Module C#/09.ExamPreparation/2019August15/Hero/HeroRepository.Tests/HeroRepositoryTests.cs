using NUnit.Framework;
using System;

namespace HeroRepository.Tests
{
    public class Tests
    {
        private Hero hero;
        private HeroRepository heroRepository;
        [SetUp]
        public void Setup()
        {
            this.heroRepository = new HeroRepository();
            this.hero = new Hero("Test", 20);

        }

        [Test]
        public void HeroConstructor()
        {

            Assert.AreEqual("Test", this.hero.Name);
            Assert.AreEqual(20, this.hero.Level);
        }

        [Test]
        public void HeroRepositoryConstructor()
        {
     
        }

        [TestCase(null)]
        public void CreateMethodIfHeroIsNull(Hero hero)
        {
            Assert.Throws<ArgumentNullException>(() => this.heroRepository.Create(hero));
        }
        [Test]
        public void CreateMethodIfHeroAlreadyExist()
        {
            this.heroRepository.Create(this.hero);
            Assert.Throws<InvalidOperationException>(() => this.heroRepository.Create(this.hero));
        }

        [TestCase(null)]
        [TestCase(" ")]
        public void RemoveMethodIfIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.heroRepository.Remove(name));
        }
        [Test]
        public void RemoveMethod()
        {
            this.heroRepository.Create(this.hero);
           var expectedBool = this.heroRepository.Remove(this.hero.Name);
            Assert.AreEqual(expectedBool, true);
        }
        [Test]
        public void GetHeroWithHighestLevel()
        {

            this.heroRepository.Create(this.hero);
            Hero expectedHero = this.heroRepository.GetHeroWithHighestLevel();

            Assert.AreEqual(expectedHero, this.hero);
        
        }
        [Test]
        public void GetHeroMethod()
        {

            this.heroRepository.Create(this.hero);
            Hero expectedHero = this.heroRepository.GetHero("Test");

            Assert.AreEqual(expectedHero, this.hero);

        }

        [Test]
        public void PropertyTest()
        {

            this.heroRepository.Create(this.hero);
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, this.heroRepository.Heroes.Count);

        }


    }
}