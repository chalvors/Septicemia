using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class damage_tests 
{
    // A Test behaves as an ordinary method
    [Test]
    public void sets_health_to_50_and_take_49_damage()
    {
        //int test = 1;
        //Assert.AreEqual(1, test);
        Bosses B1 = new Bosses();
        //Boss B1 = obj.AddComponent<Boss>();
        B1.health = 50;
        
        
        int finalHealth = B1.TakeDamage(49);
        //Debug.Log(finalHealth);
        Assert.AreEqual(1, finalHealth);
    }
    [Test]
    
    public void sets_health_to_50_and_take_51_damage()
    {
        //int test = 1;
        //Assert.AreEqual(1, test);
        Bosses B2 = new Bosses();
        B2.health = 50;
        //Debug.Log(B2.health);
        
        int finalHealth = B2.TakeDamage(51);
        //Debug.Log("++++++++++++++++++++++++++++++++++++++++");
        Debug.Log(finalHealth);
        Assert.AreEqual(0, finalHealth);
    }
    [Test]
    public void sets_health_to_50_and_take_50_damage()
    {
        //int test = 1;
        //Assert.AreEqual(1, test);
        Bosses B3 = new Bosses();
        B3.health = 50;
        //Debug.Log(B3.health);

        int finalHealth = B3.TakeDamage(50);

        Assert.AreEqual(0, finalHealth);
    }


}
