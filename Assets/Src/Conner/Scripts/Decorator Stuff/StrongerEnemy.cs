using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StrongerEnemy : Enemy
{
    BaseEnemy baseEnemy;

    private void Start()
    {
        health = 50;
        damage = 0;
    }

    public override int GetDamage()
    {
        return baseEnemy.GetDamage() + 10;
    }

    // Start is called before the first frame update
    public override int GetHealth()
    {
        return baseEnemy.GetHealth() + 10;
    }
}
