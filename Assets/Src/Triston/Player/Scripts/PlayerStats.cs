/*
 * PlayerStats.cs
 * Triston Hardcastle Peck
 * Handles the player stat upgrades utilizing the decorator pattern
 */
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/*
 * Abstract class that the subclasses inherit from
 * 
 * member variables:
 * P1 - the instance of PlayerStats used to wrap
 */
public abstract class PlayerStats
{
    public PlayerStats P1;
    //[SerializeField]
    //private int attack;
   // [SerializeField]
    //private int Maxhealth;

    public abstract int getHealth();


    public abstract int getDamage();
    


}


/*
 * BaseStats class containes the starting values for the health and attack
 */
public class BaseStats: PlayerStats
{
    //return base health
    public override int getHealth()
    {
        return 150;
    }

    //return base damage
    public override int getDamage()
    {
        return 10;
    }
}


/*
 * Base decorator class
 */
public class Decorator: PlayerStats
{
    //get base health
    public override int getHealth()
    {
        return P1.getHealth();
    }

    //get base damage
    public override int getDamage()
    {
        return P1.getDamage();
    }
}


/*
 * Health decorator used to wrap an upgrade for health
 */
public class DecorateHealth: Decorator
{
    public DecorateHealth(PlayerStats P3)
    {
        P1 = P3;
    }

    //decorate base health
    public override int getHealth()
    {
        return P1.getHealth() + 10;
    }
}


/*
 * Damage decorator used to wrap an upgrade for damage
 */
public class DecorateDamage : Decorator
{
    public DecorateDamage(PlayerStats P3)
    {
        P1 = P3;
    }

    //decorate base damage
    public override int getDamage()
    {
        return P1.getDamage() + 10;
    }
}

