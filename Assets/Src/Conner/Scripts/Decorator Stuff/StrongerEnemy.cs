using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StrongerEnemy : Enemy
{
    BaseEnemy baseEnemy;

    void Awake()
    {
        baseEnemy = GameObject.Find("MeleeEnemy").GetComponent<BaseEnemy>();
    }

    private void Start()
    {
        health = 50;
        damage = 0;
    }

    // Start is called before the first frame update
    public override void IncreaseHealth()
    {
        baseEnemy.health += 20;
    }

    protected override void IncreaseDamage()
    {
        damage += 20;
    }


}
