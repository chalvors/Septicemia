using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject player;
    private GameObject enemy;

    private Rigidbody2D rb;

    [SerializeField]
    private float force;

    private int bulletDamage;
    private float speed;

    private Vector2 startPosition;

    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Finds the player, who is our target
        player = GameObject.FindGameObjectWithTag("PLAYER");
        enemy = GameObject.FindGameObjectWithTag("PistolEnemy");

        
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
            collision.gameObject.GetComponent<Player>().TakeDamage(bulletDamage);
            ///Debug.Log("Player hit!!!");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Impassable") || collision.gameObject.CompareTag("Breakable"))
        {
            Destroy(gameObject);
            ///Debug.Log("Miss!!!");
        }
    }
}
