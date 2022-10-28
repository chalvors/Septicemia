using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerEnemy : Enemy
{
    // Start is called before the first frame update
    public void IncreaseHealth()
    {
        health += 10;
    }

    protected void IncreaseDamage()
    {
        damage += 10;
    }
}
