/*
* BaseBoss.cs
* Kyle Hash
* Main Part of my decorator patter
* Contains Multiple Classes:
*   BossStats
*   BasicBossStats
*   BossStatsUpgrade
*   BossStatsUpgradeDamage
*   BossStatsUpgradeHealth
*   BaseBoss - Child of Bosses class in Bosses.cs
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
    public virtual int getDamage()
    {
        return 0;
    }

    // --- Sets the base health initially ---
    public virtual int getHealth()
    {
        return 100;
    }
}
//----------- Boss stats for a basic boss in the early stages of the game -----------
/*
* This class is a child of BossStats and contains function to override BossStats funcions
* GetDamage() - Overrides and sets new base damage (override function)
* GetHealth() - Overrides and sets new base damage (override function)
*/
public class BasicBossStats : BossStats
{
    // --- Overwrites the base damage when boss spawns in ---
    public override int getDamage()
    {
        return 10;
    }

    // --- Overwrites the base health when boss spawns in ---
    public override int getHealth()
    {
        return 100;
    }
}

//----------- Creates an object with the base stats of a basic boss ------------------
//------------------- The stats are set in BasicBossStats -------------------
/*
* This class is a child of BossStats and contains functions to set up a wrapee Object
* GetDamage() - Overrides and sets wrapee new base damage (override function)
* GetHealth() - Overrides and sets wrapee new base health (override function)
*/
public class BossStatsUpgrade : BossStats
{
    public BossStats wrapee;

    // --- Overwrites the base damage when an upgrade is needed ---
    public override int getDamage()
    {
        return wrapee.getDamage();
    }
    // --- Overwrites the base health when an upgrade is needed ---
    public override int getHealth()
    {
        return wrapee.getHealth();
    }
}

// --------- Takes game object and creates a wrapee to upgrade the damage stat -----------
/*
* This class is a child of BossStatsUpgrade and contains functions set this.wrapee = wrapee
* BossStatsUpgradeDamage(BossStats wrapee) - Constructor and sets the wrapee sent into the class
* GetDamage() - Returns wrapee's damage + some value and applies it to the boss, "decorating it" 
*/
public class BossStatsUpgradeDamage : BossStatsUpgrade
{
    public BossStatsUpgradeDamage(BossStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int getDamage()
    {
        return wrapee.getDamage() + 5;
    }
}

// --------- Takes game object and creates a wrapee to upgrade the health stat -----------
/*
* This class is a child of BossStatsUpgrade and contains functions set this.wrapee = wrapee
* BossStatsUpgradeHealth(BossStats wrapee) - Constructor and sets the wrapee sent into the class
* GetDamage() - Returns wrapee's health + some value and applies it to the boss, "decorating it" 
*/
public class BossStatsUpgradeHealth : BossStatsUpgrade
{
    public BossStatsUpgradeHealth(BossStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int getHealth()
    {
        return wrapee.getHealth() + 10;
    }
}

/*
* This class is a child of Bosses and contains functions to set the stats of a boss to what the wrapee has 
* WrapDamage() - Updates the damage for the boss
* WrapHealth() - Updates the health for the boss
* Start() - Initializes bases stats
* FixedUpdate() - Updates Boss's stats, scales with round number
* GetDamage() - Gets the Boss's current damage
* GetHealth() - Gets the Boss's current health
*/
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

    //----------- On startup, it sets the a normal base boss's stats ------------------
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("EnemySpawner");
        stats = new BasicBossStats();

        attackDamage = getDamage();
        health = getHealth();
    }

    //----------- Updates the boss's health and attack damage, scales with the round number ------------------------
    private void FixedUpdate()
    {
        
        if (GameManager.round > upgradeCount)
        {
            wrapDamage();
            attackDamage = getDamage();
            //Debug.Log("Boss Upgraded Damage: " + attackDamage);

            wrapHealth();
            health = getHealth();
            //Debug.Log("Boss Upgraded Health: " + health);
            upgradeCount++;
        }
    }

    //Returns the damage
    public override int getDamage()
    {
        return stats.getDamage();
    }

    //Returns the health
    public override int getHealth()
    {
        return stats.getHealth();
    }
}
    





   

    

