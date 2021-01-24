using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    [TestFixture]
    public class ArenaTests
    {
        private const string NAME = "Test";
        private const int DAMAGE = 50;
        private const int HP = 100;
        private Arena warriors;
        private Warrior firstWarrior;
        private Warrior secondWarrior;
        [SetUp]
        public void Setup()
        {
            this.warriors = new Arena();
        }

        [Test]
        public void ConstructorWorkCorectly()
        {
            this.warriors = new Arena();
            Assert.AreEqual(0, this.warriors.Count);
        }
        [Test]
        public void EnrolWarriorShouldCountReturnOne()
        {
            Assert.AreEqual(0, warriors.Count);
        }

        [Test]
        public void EnrolWarriorShouldWarriorsCountReturnOne()
        {
            Assert.AreEqual(0, warriors.Warriors.Count);
        }
        [Test]
        public void EnrollMethodInvalidArgs()
        {
            this.firstWarrior = new Warrior(NAME, DAMAGE, HP);
            this.warriors.Enroll(this.firstWarrior);
            Assert.That(() => this.warriors.Enroll(new Warrior("Test", 1, 1)), Throws.InvalidOperationException);
        }
        [Test]
        public void EnrollWorkedCoreclty()
        {
            this.firstWarrior = new Warrior(NAME, DAMAGE, HP);
            int expectedResult = this.warriors.Count + 1;
            this.warriors.Enroll(this.firstWarrior);
            Assert.AreEqual(expectedResult, this.warriors.Count);
        }
        [Test]
        public void EnrollWorkedCorecltyCheckName()
        {
            this.firstWarrior = new Warrior(NAME, DAMAGE, HP);
            Warrior expectedNameResult = firstWarrior;
            this.warriors.Enroll(this.firstWarrior);
            Assert.AreEqual(expectedNameResult.Name, firstWarrior.Name);
        }
        [Test]
        [TestCase("Test", "Test2")]
        [TestCase("Test2", "Test")]
        [TestCase("Test1", "Test2")]
        public void FightMethodIfWarriorNotExist(string attackName, string defendName)
        {
            this.firstWarrior = new Warrior(NAME, DAMAGE, HP);
            this.warriors.Enroll(this.firstWarrior);
            Assert.That(() => this.warriors.Fight(attackName, defendName), Throws.InvalidOperationException);
        }
        [Test]
        [TestCase(NAME, "Test2")]
        public void FightMethodValidArgs(string attackName, string defendName)
        {
            this.firstWarrior = new Warrior(NAME, DAMAGE, HP);
            this.secondWarrior = new Warrior("Test2", 60, 80);
            this.warriors.Enroll(this.firstWarrior);
            this.warriors.Enroll(this.secondWarrior);
            int expectedResult = this.firstWarrior.HP - this.secondWarrior.Damage;
            this.warriors.Fight(attackName, defendName);
            Assert.AreEqual(expectedResult, this.firstWarrior.HP);
        }

    }
}
