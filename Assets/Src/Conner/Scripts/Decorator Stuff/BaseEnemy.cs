using Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyStats
{
    public virtual int GetDamage()
    {
        return 50;
    }

    public virtual int GetHealth()
    {
        return 50;
    }
}

public class EnemyStatsBasic : EnemyStats
{
    public override int GetDamage()
    {
        return 50;
    }

    public override int GetHealth()
    {
        return 50;
    }
}

public class EnemyStatsUpgrade : EnemyStats
{
    public EnemyStats wrapee;

    public override int GetDamage() { return wrapee.GetDamage(); }
    public override int GetHealth() { return wrapee.GetHealth(); }
}

public class EnemyStatsUpgradeDamage : EnemyStatsUpgrade
{
    public EnemyStatsUpgradeDamage(EnemyStats wrapee)
    {
        this.wrapee = wrapee;
    }

    public override int GetDamage()
    {
        return wrapee.GetDamage() + 10;
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
        return wrapee.GetHealth() + 10;
    }
}

public class BaseEnemy : Enemy
{
    EnemyStats stats;

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
        stats = new EnemyStatsBasic();

        health = 50;
        damage = 0;

        Debug.Log("Damage: " + damage);
        damage = GetDamage();
        Debug.Log("Damage: " + damage);
        wrapDamage();
        damage = GetDamage();
        Debug.Log("Damage: " + damage);
        wrapDamage();
        damage = GetDamage();
        Debug.Log("Damage: " + damage);

        health = GetHealth();
        Debug.Log("Health: " + health);
        wrapHealth();
        health = GetHealth();
        Debug.Log("Health: " + health);
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
