using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int attackstat = 20;
    private int Alive = 1;
    PlayerStats stats;
    public GameObject HealthBar;
    public GameObject GameOverScreen;

    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked;

    [SerializeField]
    private Transform circleOrigin;
    [SerializeField]
    private float radius;

    [SerializeField]
    private int roundcounter;

    public void heal() 
    {
        health = stats.GetHealth();
        HealthBar.GetComponent<HealthBar>().setHealth(health);
    }

    public int TakeDamage(int Damage)
    {
        health = health - Damage;
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            Die();
        }
        HealthBar.GetComponent<HealthBar>().setHealth(health);
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
        Time.timeScale = 0f;
        Alive=0;
        GameOverScreen.SetActive(true);
        print("YOU DIED! GAME OVER!");
    }

    // Start is called before the first frame update
    void Start()
    {
        roundcounter = 1;
        health = 150;
        HealthBar.GetComponent<HealthBar>().setMaxHealth(health);
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
        if(roundcounter < GameManager.round)
        {
            heal();
            roundcounter = GameManager.round;
        }
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    public void DetectColliders()
    {

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position,radius))
        {
            if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                continue;
            }

            BaseEnemy enemy;
            BaseBoss boss;

            if (enemy = collider.GetComponent<BaseEnemy>())
            {
                enemy.TakeDamage(stats.GetDamage());
                Debug.Log("Dealt " + stats.GetDamage() + " to " + collider.name);

            }

            if (boss = collider.GetComponent<BaseBoss>())
            {
                boss.TakeDamage(stats.GetDamage());
                Debug.Log("Dealt " + stats.GetDamage() + " to " + collider.name);

            }
        }
    }

}
