/*
* Damage_Test.cs
* Kyle Hash
* Part of my decorator patter
*/
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;


/*
* This class is used to test the bounds of Bosses taking damage
* 
* sets_health_to_50_and_take_49_damage() - 1st Test
* sets_health_to_50_and_take_51_damage() - 2nd Test
* sets_health_to_50_and_take_50_damage() -  3rd Test
*/
public class damage_tests : MonoBehaviour 
{
    // -------- If boss has 50 health and takes 49 damage the boss's health should be 1 -------------   
    [Test]
    public void sets_health_to_50_and_take_49_damage()
    {
        
        Bosses B1 = new Bosses();
        int finalHealth = 0;
        B1.health = 50;
   
        finalHealth = B1.testTakeDamage(49);
        Assert.AreEqual(1, finalHealth);
    }

    // -------- If boss has 50 health and takes 51 damage the boss's health should be 0 not -1 ------------- 
    [Test]
    public void sets_health_to_50_and_take_51_damage()
    {
     
        Bosses B2 = new Bosses();
        B2.health = 50;
        
        int finalHealth = B2.testTakeDamage(51);
        Assert.AreEqual(0, finalHealth);
    }

    // -------- If boss has 50 health and takes 50 damage the boss's health should be 0 ------------- 
    [Test]
    public void sets_health_to_50_and_take_50_damage()
    {
      
        Bosses B3 = new Bosses();
        B3.health = 50;

        int finalHealth = B3.testTakeDamage(50);
        Assert.AreEqual(0, finalHealth);
    }
}
