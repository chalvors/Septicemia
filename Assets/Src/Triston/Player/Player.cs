using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int attackstat = 10;
    private int Alive = 1;
    PlayerStats stats;

    
    public void heal() 
    {
        health = stats.GetHealth();
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

    public void attack()
    {
        Debug.Log("attack strength is: " + stats.GetDamage());
    }

    void Die()
    {
        Alive=0;
        print("YOU DIED! GAME OVER!");
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        stats = new BaseStats();
    }

    void decorateHealth()
    {
        stats = new DecorateHealth(stats);
    }

    void decorateDamage()
    {
        stats = new DecorateDamage(stats);
    }

    private float timer = 0.0f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2.0)
        {
            timer = 0.0f;
            Debug.Log("Current health is: " + stats.GetHealth() + " current damage is: " + stats.GetDamage());
            decorateHealth();
            decorateDamage();
            Debug.Log("Current health is: " + stats.GetHealth() + " current damage is: " + stats.GetDamage());
        }
    }
}
