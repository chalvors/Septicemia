using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class player_damage_tests
{
    // A Test behaves as an ordinary method
    [Test]
    public void sets_health_to_150_and_take_149_damage()
    {
        TestPlayer P1 = new();
        
        int finalHealth = P1.takeDamage(149);

        Assert.AreEqual(1, finalHealth);
    }
    [Test]
    
    public void sets_health_to_150_and_take_151_damage()
    {

        TestPlayer P1 = new();

        int finalHealth = P1.takeDamage(151);

        Assert.AreEqual(-1, finalHealth);
    }
    [Test]
    public void sets_health_to_150_and_take_150_damage()
    {

        TestPlayer P1 = new();

        int finalHealth = P1.takeDamage(150);

        Assert.AreEqual(0, finalHealth);
    }


}
