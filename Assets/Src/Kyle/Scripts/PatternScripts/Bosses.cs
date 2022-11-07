using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosses : MonoBehaviour
{
    // ---------- Creating Stats for Boss -----------------
    //protected float moveSpeed;
    //[SerializeField]
    public int health; // Needed to make public for bounds tests
    //[SerializeField]
    public int attackDamage; // Needed to make public for bounds tests


    private Rigidbody2D rb;
    private Vector2 movement; //Wont need this after getting pathfinding
    private CircleCollider2D bossCollider;
    

   
    // ----------------- Player Takes Damage From Boss ---------------------
    virtual protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject


            if (collider.GetComponent<Player>() != null)
            {
                collider.GetComponent<Player>().TakeDamage(attackDamage);
                takeDamage(collider.GetComponent<Player>().attackstat);
                //canDealDamage = false;
                //StartCoroutine(DamageCooldown());
            }
            Debug.Log("Damage dealt to the player!");
            Debug.Log("Player health: " + collider.GetComponent<Player>().health);
        }
    }

    // ------------ Boss Takes Damage Dealt from the Player ------------------------
    // --------- Had to be a public function for bounds testing --------------
    virtual public int takeDamage(int playerAttack){

        //Take the player's attack stat and have it affect boss's health
        health = health - playerAttack;
        Debug.Log("Boss's Health: " + health);

        // --- Check to see if Boss Died ---
        if (health <= 0){
            Destroy(gameObject);
            Debug.Log("You just killed a boss!!!");
        }
        return health;
    }

    // --------------- Returns the Boss's Current Health -----------------------
    public virtual int GetHealth()
    {
        return health;
    }
    // ---------------- Returns the Boss's Current Attack Damage ---------------------
    public virtual int GetDamage()
    {
        return attackDamage;
    }





}
