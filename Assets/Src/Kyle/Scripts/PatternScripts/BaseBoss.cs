using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//----------- Boss stats for a boss upon first instantiation -----------
public class BossStats
{
    public virtual int GetDamage()
    {
        return 0;
    }

    public virtual int GetHealth()
    {
        return 50;
    }
}
//----------- Boss stats for a basic boss in the early stages of the game -----------
public class BasicBossStats : BossStats
{
    public override int GetDamage()
    {
        return 10;
    }

    public override int GetHealth()
    {
        return 100;
    }
}

//----------- Creates an object with the base stats of a basic boss ------------------
//------------------- The stats are set in BasicBossStats -------------------
public class BossStatsUpgrade : BossStats
{
    public BossStats wrapee;

    public override int GetDamage()
    {
        return wrapee.GetDamage();
    }

    public override int GetHealth()
    {
        return wrapee.GetHealth();
    }
}

// --------- Takes game object and creates a wrapee to upgrade the damage stat -----------
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
        return wrapee.GetHealth() + 5;
    }
}

public class BaseBoss : Bosses
{
    BossStats stats;

    private void wrapDamage()
    {
        stats = new BossStatsUpgradeDamage(stats);
    }

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
        //int upgradeCount = 0;

        //if (GameManager.round > upgradeCount)
        //{
            wrapDamage();
            attackDamage = GetDamage();
            Debug.Log("Boss Upgraded Damage: " + attackDamage);

            wrapHealth();
            health = GetHealth();
            Debug.Log("Boss Upgraded Health: " + health);
        //}
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
    





   

    

