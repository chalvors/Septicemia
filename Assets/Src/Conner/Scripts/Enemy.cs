using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Set default values if data is not set for some reason
    [SerializeField]
    private int damage = 5;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private EnemyData data;

    //All enemies will interact with the player in some way
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Find Player GameObject
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    // Update is called once per frame
    void Update()
    {
        //Continuously approach the player
        Approach();
    }

    private void Approach()
    {
        //Change the position of the enemy in the direction of the Player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

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
        }
    }
}
