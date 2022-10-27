using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Set default values if data is not set
    protected int health = 100;
    protected int damage = 0;

    protected bool canDealDamage;
    protected EnemyData data;

    //All enemies will interact with the player in some way, this allows us to get information from the player
    public GameObject player;


    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject

            
            if(collider.GetComponent<Player>() != null)
            {
                collider.GetComponent<Player>().TakeDamage(damage);
            }
            Debug.Log("Damage dealt to the player!");
        }
    }
}
