using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class attack_change_test : Enemy
{
    [Test]
    public void take_5_damage()
    {
        TestEnemy E1 = new TestEnemy();
        E1.damage = 5;
        E1.health = 20;

        float newHealth = E1.takeDamage(E1.damage);

        Assert.AreEqual(15, newHealth);
    }

    [Test]
    public void take_20_damage()
    {
        TestEnemy E1 = new TestEnemy();
        E1.damage = 20;
        E1.health = 20;

        float newHealth = E1.takeDamage(E1.damage);

        Assert.AreEqual(0, newHealth);
    }

    [Test]
    public void take_25_damage()
    {
        TestEnemy E1 = new TestEnemy();
        E1.damage = 25;
        E1.health = 20;

        float newHealth = E1.takeDamage(E1.damage);

        Assert.AreEqual(0, newHealth);
    }
}
