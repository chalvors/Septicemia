using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class PlayerStats
{
    public PlayerStats P1;
    public int Maxhealth;

    public abstract int GetHealth();


    public abstract int GetDamage();
    


}

public class BaseStats: PlayerStats
{
    
    public override int GetHealth()
    {
        return 100;
    }

    public override int GetDamage()
    {
        return 10;
    }
}

public class Decorator: PlayerStats
{
    public override int GetHealth()
    {
        return P1.GetHealth();
    }

    public override int GetDamage()
    {
        return P1.GetDamage();
    }
}

public class DecorateHealth: Decorator
{
    public DecorateHealth(PlayerStats P3)
    {
        P1 = P3;
    }

    public override int GetHealth()
    {
        return P1.GetHealth() + 10;
    }
}

public class DecorateDamage : Decorator
{
    public DecorateDamage(PlayerStats P3)
    {
        P1 = P3;
    }

    public override int GetDamage()
    {
        return P1.GetDamage() + 10;
    }
}