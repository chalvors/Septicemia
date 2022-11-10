using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    //Set default values if data is not set
    protected int health = 100;
    protected int damage = 0;
    protected float maxSpeed = 2f;

    protected bool canDealDamage = true;
    //protected EnemyData data;

    public GameObject counter;

    [SerializeField]
    private AudioClip takeDamage;

    [SerializeField]
    private AudioClip death;


    virtual protected void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log(collider.gameObject.tag);
        if (collider.gameObject.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject
            if(collider.gameObject.GetComponent<Player>() != null && canDealDamage)
            {
                Debug.Log("Got here, damage is " + damage);
                collider.gameObject.GetComponent<Player>().TakeDamage(damage);
                //TakeDamage(collider.GetComponent<Player>().attackstat);
                canDealDamage = false;
                StartCoroutine(DamageCooldown());
            }
            Debug.Log("Damage dealt to the player!");
            //Debug.Log("Player health: " + collider.GetComponent<Player>().health);
        }
    }

    virtual protected IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDealDamage = true;
    }

    virtual public int TakeDamage(int playerDamage)
    {
        health = health - playerDamage;
        Debug.Log("Enemy health: " + health);
        AudioManager.Instance.PlaySound(takeDamage);

        if (health <= 0)
        {
            AudioManager.Instance.PlaySound(death);
            Destroy(gameObject);
            counter.GetComponent<SpawnScript>().enemiesRemaining--;
            Debug.Log("Enemies remaining: " + counter.GetComponent<SpawnScript>().enemiesRemaining);
        }

        return health;
    }

    public virtual int GetHealth()
    {
        return health;
    }

    public virtual int GetDamage()
    {
        return damage;
    }
}
