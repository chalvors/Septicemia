using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Set default values if data is not set for some reason
    public int health = 25;

    public int damage = 15;

    public EnemyData data;

    //All enemies will interact with the player in some way
    public GameObject player;

    /*
    private void Approach()
    {
        //Change the position of the enemy in the direction of the Player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    */

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject

            /*
            if(collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
            }*/
            Debug.Log("Damage dealt to the player!");
        }
    }
}
