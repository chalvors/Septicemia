using System;
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

    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;
    
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

    public void Attack()
    {
        if(attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        Debug.Log("attack strength is: " + stats.GetDamage());
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
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


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }


}
