/*using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class player_damage_tests
{
    // A Test behaves as an ordinary method
    [Test]
    public void sets_health_to_100_and_take_99_damage()
    {
        Player P1 = new Player();
        P1.health = 100;
        
        int finalHealth = P1.TakeDamage(99);

        Assert.AreEqual(1, finalHealth);
    }
    [Test]
    
    public void sets_health_to_100_and_take_101_damage()
    {

        Player P1 = new Player();
        P1.health = 100;

        int finalHealth = P1.TakeDamage(101);

        Assert.AreEqual(-1, finalHealth);
    }
    [Test]
    public void sets_health_to_100_and_take_100_damage()
    {

        Player P1 = new Player();
        P1.health = 100;

        int finalHealth = P1.TakeDamage(100);

        Assert.AreEqual(0, finalHealth);
    }


}
*/