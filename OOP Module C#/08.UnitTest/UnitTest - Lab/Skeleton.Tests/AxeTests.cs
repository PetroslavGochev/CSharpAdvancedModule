using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(10,15,10,10,14)]
    [TestCase(15,25,10,10,24)]
    public void IfWeaponLosesDurabilityAfterEachAttack(
        int attack, 
        int durability,
        int health,
        int experience,
        int expectedResult)
    {
        //Arrange 
        Axe axe = new Axe(attack, durability);
        Dummy dummy = new Dummy(health, experience);

        //Act
        
        axe.Attack(dummy);
        
        //Assert

        Assert.AreEqual(expectedResult, axe.DurabilityPoints);
    }

    [Test]
    [TestCase(10, -2, 10, 10)]
    public void AttackWithBrokenWeapon(
       int attack,
       int durability,
       int health,
       int experience)
    {
        //Arrange 
        Axe axe = new Axe(attack, durability);
        Dummy dummy = new Dummy(health, experience);


        //Assert

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}