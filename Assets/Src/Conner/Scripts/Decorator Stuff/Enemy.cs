using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Set default values if data is not set
    protected int health = 100;
    protected int damage = 0;

    protected bool canDealDamage = true;
    protected EnemyData data;

    
    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject

            
            if(collider.GetComponent<Player>() != null && canDealDamage)
            {
                collider.GetComponent<Player>().TakeDamage(damage);
                TakeDamage(collider.GetComponent<Player>().attackstat);
                canDealDamage = false;
                StartCoroutine(DamageCooldown());
            }
            Debug.Log("Damage dealt to the player!");
            Debug.Log("Player health: " + collider.GetComponent<Player>().health);
        }
    }

    protected IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(0.5f);
        canDealDamage = true;
    }

    protected int TakeDamage(int playerDamage)
    {
        health = health - playerDamage;
        Debug.Log("Enemy health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy has died");
        }

        return health;
    }
}
