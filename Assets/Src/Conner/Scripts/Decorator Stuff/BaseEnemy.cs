/*
* BaseEnemy.cs
* Conner Mullins
* The script that determines the behavior of the BaseEnemy
*/
using UnityEngine;


//These are the base stats of the melee enemy, which override the values from EnemyStats
public class EnemyMeleeStats : EnemyStats
{
    public override int getDamage()
    {
        return 5;
    }

    public override int getHealth()
    {
        return 30;
    }
}

public class BaseEnemy : Enemy
{
    EnemyStats stats;

    int upgradeCount;

    private void wrapDamage()
    {
        stats = new EnemyStatsUpgradeDamage(stats);
    }

    private void wrapHealth()
    {
        stats = new EnemyStatsUpgradeHealth(stats);
    }

    //Enemy attack delay
    private float attackDelay;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("EnemySpawner");
        upgradeCount = 1;
        stats = new EnemyMeleeStats();

        damage = getDamage();
        health = getHealth();
    }

    private void FixedUpdate()
    {
        if (GameManager.round > upgradeCount)
        {
            wrapDamage();
            damage = getDamage();

            wrapHealth();
            health = getHealth();
            Debug.Log("Current MeleeEnemy Health: " + health);
            Debug.Log("Current MeleeEnemy Damage: " + damage);

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
