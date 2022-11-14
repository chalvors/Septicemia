using UnityEngine;

//These are the stats of every enemy upon instantiation
public class EnemyStats
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

//These are the base stats of the melee enemy, which override the values from EnemyStats
public class EnemyStatsBasic : EnemyStats
{
    public override int GetDamage()
    {
        return 5;
    }

    public override int GetHealth()
    {
        return 30;
    }
}

//Creates an object with the base stats of the melee enemy, which is decided in EnemyStatsBasic
public class EnemyStatsUpgrade : EnemyStats
{
    public EnemyStats wrapee;

    public override int GetDamage() 
    { 
        return wrapee.GetDamage(); 
    }

    public override int GetHealth() 
    { 
        return wrapee.GetHealth(); 
    }
}

public class EnemyStatsUpgradeDamage : EnemyStatsUpgrade
{
    public EnemyStatsUpgradeDamage(EnemyStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int GetDamage()
    {
        return wrapee.GetDamage() + 2;
    }
}

public class EnemyStatsUpgradeHealth : EnemyStatsUpgrade
{
    public EnemyStatsUpgradeHealth(EnemyStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int GetHealth()
    {
        return wrapee.GetHealth() + 5;
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
        stats = new EnemyStatsBasic();

        health = 50;
        damage = 5;
    }

    private void FixedUpdate()
    {
        if (GameManager.round > upgradeCount)
        {
            wrapDamage();
            damage = GetDamage();

            wrapHealth();
            health = GetHealth();
            Debug.Log("Current Enemy Health: " + health);
            Debug.Log("Current Enemy Damage: " + damage);

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
