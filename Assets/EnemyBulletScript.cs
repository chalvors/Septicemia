using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Finds the player, who is our target
        player = GameObject.FindGameObjectWithTag("PLAYER");

        //Sends the bullet in the direction of the player
        Vector3 direction = player.transform.position - transform.position;

        //Determines the speed of the bullet
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        //Rotates the bullets to face the direction that they will travel in. Can rotate the sprite by adding or subtracting from rot
        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        //Bullet collisions with the player's circle collider will do nothing since that is used for player attacks
        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), player.GetComponent<CircleCollider2D>());
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        //If the bullet has existed for 5 seconds, destroy it
        if (timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(15);
            Debug.Log("Player hit!!!");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Impassable") || collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(gameObject);
            Debug.Log("Miss!!!");
        }
    }
}
