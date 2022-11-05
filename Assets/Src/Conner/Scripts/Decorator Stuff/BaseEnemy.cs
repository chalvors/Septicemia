using Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseEnemy : Enemy
{
    //Enemy attack delay
    private float attackDelay;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        damage = 0;

        //Debug.Log(health);
        GetHealth();
        //Debug.Log(health);
    }

    //Returns the damage
    public override int GetDamage()
    {
        return damage;
    }

    //Returns the health
    public override int GetHealth()
    {
        return health;
    }
}
