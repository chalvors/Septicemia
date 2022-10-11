using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int attackstat = 10;
    private int Alive = 1;

    public int AttackUpgrade()
    {
        attackstat = attackstat + 1;
        return attackstat;
    }

    public int TakeDamage(int Damage)
    {
        health = health - Damage;
        if (health <= 0)
        {
            Die();
        }
        return health;
    }

    void Die()
    {
        Alive=0;
        print("YOU DIED! GAME OVER!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
