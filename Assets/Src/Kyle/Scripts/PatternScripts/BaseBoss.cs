/*
* BaseBoss.cs
* Kyle Hash
* Part of my decorator patter
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//----------- Boss stats for a boss upon first instantiation -----------
/*
* Contains base functions for initiating a boss
* GetDamage() - Sets base damage (virtual function)
* GetHealth() - Sets the base health (virtual funciton)
*/
public class BossStats
{
    // --- Sets the base damage initially ---
    public virtual int GetDamage()
    {
        return 0;
    }

    // --- Sets the base health initially ---
    public virtual int GetHealth()
    {
        return 50;
    }
}
//----------- Boss stats for a basic boss in the early stages of the game -----------
/*
* This class is a child of BossStats and contains function to overwrite BossStats funcions
* GetDamage() - Overrides and sets new base damage (virtual function)
* GetHealth() - Overrides and sets new base damage (virtual function)
*/
public class BasicBossStats : BossStats
{
    // --- Overwrites the base damage when boss spawns in ---
    public override int GetDamage()
    {
        return 10;
    }

    // --- Overwrites the base health when boss spawns in ---
    public override int GetHealth()
    {
        return 100;
    }
}

//----------- Creates an object with the base stats of a basic boss ------------------
//------------------- The stats are set in BasicBossStats -------------------
/*
* This class is a child of BossStats and contains functions to wrap my Boss Object
* GetDamage() - Overrides and sets new base damage (override function)
* GetHealth() - Overrides and sets new base damage (override function)
*/
public class BossStatsUpgrade : BossStats
{
    public BossStats wrapee;

    // --- Overwrites the base damage when an upgrade is needed ---
    public override int GetDamage()
    {
        return wrapee.GetDamage();
    }
    // --- Overwrites the base health when an upgrade is needed ---
    public override int GetHealth()
    {
        return wrapee.GetHealth();
    }
}

// --------- Takes game object and creates a wrapee to upgrade the damage stat -----------
/*
* This class is a child of BossStatsUpgrade and contains functions set this.wrapee = wrapee
* BossStatsUpgradeDamage() - 
* BossStatsUpgradeHealth() - 
*/
public class BossStatsUpgradeDamage : BossStatsUpgrade
{
    public BossStatsUpgradeDamage(BossStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int GetDamage()
    {
        return wrapee.GetDamage() + 5;
    }
}

// --------- Takes game object and creates a wrapee to upgrade the health stat -----------
public class BossStatsUpgradeHealth : BossStatsUpgrade
{
    public BossStatsUpgradeHealth(BossStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int GetHealth()
    {
        return wrapee.GetHealth() + 10;
    }
}

public class BaseBoss : Bosses
{
    BossStats stats;
    int upgradeCount = 0;
    

    //-------- Uses the wrapee created in BossStatsUpgradeDamage and applies it to stats object -----------
    private void wrapDamage()
    {
        stats = new BossStatsUpgradeDamage(stats);
    }

    //-------- Uses the wrapee created in BossStatsUpgradeHealth and applies it to stats object -----------
    private void wrapHealth()
    {
        stats = new BossStatsUpgradeHealth(stats);
    }

    void Start()
    {
        stats = new BasicBossStats();

        attackDamage = GetDamage();
        health = GetHealth();
    }

    private void FixedUpdate()
    {
        
        if (GameManager.round > upgradeCount)
        {
            wrapDamage();
            attackDamage = GetDamage();
            Debug.Log("Boss Upgraded Damage: " + attackDamage);

            wrapHealth();
            health = GetHealth();
            Debug.Log("Boss Upgraded Health: " + health);
            upgradeCount++;
        }
    }

    //Returns the damage
    public override int GetDamage()
    {
        return stats.GetDamage();
    }

    //Returns the health
    public override int GetHealth()
    {
        return stats.GetHealth();
    }
}
    





   

    

