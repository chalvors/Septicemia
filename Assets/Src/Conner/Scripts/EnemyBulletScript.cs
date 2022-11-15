/*
* EnemyBulletScript.cs
* Conner Mullins
* A script to determine the behavior and damage of the enemy bullets
*/
using System;
using UnityEngine;


/*
 * This is the class for the bullets fired by pistol and rifle enemies which instantiates and determines their direction, speed, damage, and fire rate
 * 
 * member variables:
 * player - Finds the player, which will be the target for our bullet
 * enemy - Used to get the damage for the bullet
 * rb - The rigidbody2d of the bullet
 * force - Used to determine how fast the bullet will be traveling
 * bulletDamage - The amount of health that will be removed from the player for each bullet
 * timer - Used to check how long a bullet has existed within the scene
 */
public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;
    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    private int bulletDamage;
    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Error catching
        try
        {
            //Finds the player, who is our target
            player = GameObject.FindGameObjectWithTag("PLAYER");
            //Finds the enemy who fired the bullet
            enemy = GameObject.FindGameObjectWithTag("PistolEnemy");
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        }

        bulletDamage = enemy.GetComponent<PistolEnemy>().damage;

        //Sends the bullet in the direction of the player
        Vector3 direction = player.transform.position - transform.position;

        //Determines the speed of the bullet
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        
        //Rotates the bullets to face the direction that they will travel in. Can rotate the sprite by adding or subtracting from rot
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    void FixedUpdate()
    {
        //Increment the local timer on each bullet
        timer += Time.deltaTime;

        //If a bullet has existed for 5 seconds, destroy it
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If the bullet has collided with the Player
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            //Deal damage to the Player by calling the Player's takeDamage function, then destroy the bullet
            collision.gameObject.GetComponent<Player>().takeDamage(bulletDamage);
            Destroy(gameObject);
        }
        //If the bullet has collided with cover, a wall, or a building
        else if (collision.gameObject.CompareTag("Impassable") || collision.gameObject.CompareTag("Breakable"))
        {
            //Destroy the bullet
            Destroy(gameObject);
        }
    }
}


