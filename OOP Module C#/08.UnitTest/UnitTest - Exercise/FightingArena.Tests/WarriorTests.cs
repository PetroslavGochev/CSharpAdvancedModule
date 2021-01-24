using NUnit.Framework;

namespace Tests
{
    using FightingArena;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private const string NAME = "Attack";
        private const int DAMAGE = 50;
        private const int HP = 100;
        private Warrior warior;
        [SetUp]
        public void Setup()
        {
            this.warior = new Warrior(NAME, DAMAGE, HP);         
        }

        [Test]
        public void CreateWarriorTestHP()
        {
            int expectedHp = HP;
            this.warior = new Warrior(NAME, DAMAGE, HP);
            Assert.AreEqual(expectedHp,warior.HP);
        }
        [Test]
        public void CreateWarriorTestDAMAGE()
        {
            int expectedDamage = DAMAGE;
            this.warior = new Warrior(NAME, DAMAGE, HP);
            Assert.AreEqual(expectedDamage, warior.Damage);
        }
        [Test]
        public void CreateWarriorTestName()
        {
            string expectedName = NAME;
            this.warior = new Warrior(NAME, DAMAGE, HP);
            Assert.AreEqual(expectedName, warior.Name);
        }
        [Test]
        public void CreateWarriorTest()
        {
            this.warior = new Warrior(NAME, DAMAGE, HP);
            Assert.IsNotNull(warior);
        }
        [Test]
        [TestCase(null,DAMAGE,HP)]
        [TestCase(" ",DAMAGE,HP)]
        [TestCase("",DAMAGE,HP)]
        [TestCase(NAME,0,HP)]
        [TestCase(NAME,-1,HP)]
        [TestCase(NAME,DAMAGE,-1)]
        public void CreateWarriorWithInvalidArgs(string name,int damage,int hp)
        {
            this.warior = new Warrior(NAME, DAMAGE, HP);
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }
        [Test]
        [TestCase("Defend",50,60)]
        public void TestWarriorAttack(string name,int damage,int hp)
        {
            Warrior defend = new Warrior(name, damage, hp);
            int expectedHP = this.warior.HP - damage;
            this.warior.Attack(defend);
            Assert.AreEqual(expectedHP, this.warior.HP);
        }
        [Test]
        [TestCase("Defend", 50, 40)]
        public void TestWarriorAttackIfDefendHpIsLessThanDamage(string name, int damage, int hp)
        {
            Warrior defend = new Warrior(name, damage, hp);
            int expectedHP = 0;
            this.warior.Attack(defend);
            Assert.AreEqual(expectedHP, defend.HP);
        }
        [Test]
        [TestCase("Defend", 50, 60)]
        public void TestWarriorAttackIfDefendHpIsMoreThanDamage(string name, int damage, int hp)
        {
            Warrior defend = new Warrior(name, damage, hp);
            int expectedHP = hp - this.warior.Damage;
            this.warior.Attack(defend);
            Assert.AreEqual(expectedHP, defend.HP);
        }
        [Test]
        [TestCase("Attack", 50, 30,"Defend",100,90)]
        [TestCase("Attack", 50, 20,"Defend",100,90)]
        [TestCase("Attack", 100, 50,"Defend",100,30)]
        [TestCase("Attack", 100, 50,"Defend",100,20)]
        [TestCase("Attack", 60, 50,"Defend",100,100)]
        public void InvalidWarriorAttack(
            string attackerName,
            int attackerDamage, 
            int attackerHp,
            string defendName,
            int defendDamage,
            int defendHp
            )
        {
            Warrior attack = new Warrior(attackerName, attackerDamage, attackerHp);
            Warrior defend = new Warrior(defendName, defendDamage, defendHp);
            Assert.That(() => attack.Attack(defend), Throws.InvalidOperationException);
        }

    }
}