using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses : MonoBehaviour
{
    // ---------- Creating Stats for Boss -----------------
    protected float moveSpeed;
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int attackDamage;
    private Rigidbody2D rb;
    private Vector2 movement; //Wont need this after getting pathfinding
    private CircleCollider2D bossCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bossCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void attackPlayer(){
        //Player.TakeDamage(attackDamage);
    }
    public virtual int takeDamage(int playerAttack){
        //Take the player's attack stat and have it affect boss's health
        health = health - playerAttack;
        Debug.Log("Boss's Health: " + health);
        return health;
    }
     void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            takeDamage(attackDamage);
        }
    }
}
