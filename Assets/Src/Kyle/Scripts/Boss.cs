using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int health = 100;
    public int attackDamage = 20;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    //public GameObject Player;

    private CircleCollider2D bossCollider;
    //player = gameObject.Find("Player").GetComponent<Rigidbody2D>();
    

    void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            Attack(attackDamage);
        }
    }

    public int Attack(int attackDamage)
    {
        // This is not correct, this is just for test case
        // This function should deal damage to the player, not the boss
        // I only built it this way because we currently don't have an attack fucntion that I can call from the player
        // player.health = player.health - 20;
        health = health - attackDamage;
        print("i'll get you for that in the full game!");
        Debug.Log(health);
        if (health <= 0)
        {
            return health;
            Die(bossCollider);
            
        }
        return health;
    }
    public int ChangeAttack(int attackDamage, int changedAttackDamage)
    {
        //This function will change the boss's attack damage
        int currentAttackDamage = attackDamage;

        currentAttackDamage = currentAttackDamage - changedAttackDamage;
        return currentAttackDamage;

    }
    void Die(Collider2D interBox)
    {
        print("You killed the biggest enemy");
        if (interBox.tag == "BOSS")
        {
            Destroy(interBox.gameObject);
            

            bossCollider.enabled = false;
        }
    }

    void Start()
    {
        //Player.GameObject.tag = "Player";
        //Player = GetComponent("Player");
        //player = Player.gameObject.transform;
        rb = this.GetComponent<Rigidbody2D>();
        bossCollider = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
       
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    void FixedUpdate()
    {
        moveBoss(movement);
    }
    void moveBoss(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
