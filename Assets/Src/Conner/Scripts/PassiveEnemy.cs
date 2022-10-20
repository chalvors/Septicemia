using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PassiveEnemy : Enemy
{
    // EnemyData data;
    //private GameObject player;

    private void Start()
    {
        data.health = 100;
        data.damage = 0;
        data.speed = 1;

        //Find Player GameObject
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -1 * data.speed * Time.deltaTime);
    }

    public int TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            return 0;
        }
        else
            return health;
    }
}
