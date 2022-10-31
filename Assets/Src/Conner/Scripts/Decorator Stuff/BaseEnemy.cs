using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        damage = 0;

        //IncreaseHealth();

    }

    public override int GetDamage()
    {
        return damage;
    }

    public override int GetHealth()
    {
        return damage;
    }
}
