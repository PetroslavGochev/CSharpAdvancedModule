using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
//• Dummy loses health if attacked
//•	Dead Dummy throws exception if attacked
//•	Dead Dummy can give XP
//•	Alive Dummy can't give XP

    [Test]
    [TestCase(10,10,5)]
    public void LossesHealthIfAttacked(int health, int experience,int attackPoints)
    {
        Dummy target = new Dummy(health, experience);

        target.TakeAttack(attackPoints);
        int expectedResult = health - attackPoints;

        Assert.AreEqual(expectedResult, target.Health);
    }
    [Test]
    [TestCase(-5, 10, 10)]
    public void ThrowExceptionIfAttackPointsAreMoreThanHealth(int health, int experience, int attackPoints)
    {
        Dummy target = new Dummy(health, experience);


        Assert.Throws<InvalidOperationException>(() => target.TakeAttack(attackPoints));
    }
    [Test]
    [TestCase(-5, 10)]
    public void IfDummyCanGiveXp(int health, int experience)
    {
        Dummy target = new Dummy(health, experience);


        int expectedResult = target.GiveExperience();

        Assert.AreEqual(expectedResult,experience);
    }
    [Test]
    [TestCase(10, 10)]
    public void IfDummyCantGiveXp(int health, int experience)
    {
        Dummy target = new Dummy(health, experience);


        Assert.Throws<InvalidOperationException>(() => target.GiveExperience());
    }
}
