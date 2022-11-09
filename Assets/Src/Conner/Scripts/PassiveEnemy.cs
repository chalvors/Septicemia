using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class PassiveEnemy : Enemy
{
    private GameObject player;

    private void Start()
    {
        health = 100;
        damage = 0;

        //Find Player GameObject
        //player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -1 * data.speed * Time.deltaTime);
    }

    new public int TakeDamage(int damage)
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
