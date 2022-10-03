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
        Boss B1 = new Boss();
        //Boss B1 = obj.AddComponent<Boss>();
        B1.health = 50;
        
        
        int finalHealth = B1.Attack(49);
        //Debug.Log(finalHealth);
        Assert.AreEqual(1, finalHealth);
    }
    [Test]
    
    public void sets_health_to_50_and_take_51_damage()
    {
        //int test = 1;
        //Assert.AreEqual(1, test);
        Boss B2 = new Boss();
        B2.health = 50;
        //Debug.Log(B2.health);
        
        int finalHealth = B2.Attack(51);
        //Debug.Log("++++++++++++++++++++++++++++++++++++++++");
        //Debug.Log(finalHealth);
        Assert.AreEqual(-1, finalHealth);
    }
    [Test]
    public void sets_health_to_50_and_take_50_damage()
    {
        //int test = 1;
        //Assert.AreEqual(1, test);
        Boss B3 = new Boss();
        B3.health = 50;
        //Debug.Log(B3.health);

        int finalHealth = B3.Attack(50);

        Assert.AreEqual(0, finalHealth);
    }


}
