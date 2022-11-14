/*
* BaseEnemy.cs
* Conner Mullins
* The script that determines the behavior of the BaseEnemy
*/
using UnityEngine;


//These are the base stats of the melee enemy, which override the values from EnemyStats
public class EnemyMeleeStats : EnemyStats
{
    //Base damage for the melee enemy
    public override int getDamage()
    {
        return 5;
    }

    //Base health for the melee enemy
    public override int getHealth()
    {
        return 30;
    }
}


/*
 * This is the melee enemy subclass of Enemy.cs, which determines the stats of all melee enemies
 * 
 * member variables:
 * stats - Placeholder for the damage and health stats. This is what is decorated by my decorator pattern
 * upgradeCount - Keeps track of how many upgrades the enemies have had
 */
public class BaseEnemy : Enemy
{
    EnemyStats stats;

    int upgradeCount;

    //Pass the enemy stats placeholder to the damage upgrade function
    private void wrapDamage()
    {
        stats = new EnemyStatsUpgradeDamage(stats);
    }

    //Pass the enemy stats placeholder to the health upgrade function
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

        //Set the damage and health placeholder
        stats = new EnemyMeleeStats();

        //Set the starting damage and health of the melee enemy
        damage = getDamage();
        health = getHealth();
    }

    //Check to see if the round has changed
    private void FixedUpdate()
    {
        //If the round has incremented
        if (GameManager.round > upgradeCount)
        {
            //Increase the damage of the melee enemy
            wrapDamage();
            damage = getDamage();

            //Increase the health of the melee enemy
            wrapHealth();
            health = getHealth();
            Debug.Log("Current MeleeEnemy Health: " + health);
            Debug.Log("Current MeleeEnemy Damage: " + damage);

            upgradeCount++;
        }
    }

    //Overrides the getDamage function in Enemy.cs and returns the base damage for melee enemies
    public override int getDamage()
    {
        return stats.getDamage();
    }

    //Overrides the getDamage function in Enemy.cs and returns the base health for melee enemies
    public override int getHealth()
    {
        return stats.getHealth();
    }
}

