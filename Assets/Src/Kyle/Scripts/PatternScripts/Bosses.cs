/*
* Bosses.cs
* Kyle Hash
* Part of my decorator patter
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* This class is the parent for all of the other Boss Classes I will be using
* OnCollisionEnter2D(Collision2D collider) - Deals damage to the player when Boss collides
* DamageCooldown() - Sets a delay so Boss can't do damage quickly
* TakeDamage(int playerAttack) - Called in the player scripts when Boss needs to take damage from an attack
* dropBrain() -  Drops a brain object to be picked up by the player
* GetHealth() - Returns the Boss's current Health
* GetDamage() - Returns the Boss's current Damage
*/
public class Bosses : MonoBehaviour
{
    // ---------- Creating Stats for Boss -----------------
    
    public int health; // Needed to make public for bounds tests
    public int attackDamage; // Needed to make public for bounds tests

    [SerializeField]
    private GameObject brain;    // Boss item drop
    [SerializeField]
    private AudioClip _takeDamage;      //Auido for taking damage
    
    private bool isAlive = true;        // Is the boss alive?
   
    protected bool canDealDamage = true;
    protected GameObject counter;         // Counts how many enemies/bosses are left in the round


    // ----------------- Player Takes Damage From Boss ---------------------
    virtual protected void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject
   

            if (collider.gameObject.GetComponent<Player>() != null)
            {
                collider.gameObject.GetComponent<Player>().takeDamage(attackDamage); // Calls Triston's TakeDamage function for the player
                
                //takeDamage(collider.GetComponent<Player>().attackstat);    // Calls my takeDamage function for the boss
                canDealDamage = false;
                StartCoroutine(DamageCooldown());
            }
            //Debug.Log("Damage dealt to the player!");
            //Debug.Log("Player health: " + collider.GetComponent<Player>().health);
        }
    }

    // ---------------- 1 second cooldown for a Boss Attack -----------------------------
    virtual protected IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDealDamage = true;
    }
    // ------------ Boss Takes Damage Dealt from the Player ------------------------
    // --------- Had to be a public function for bounds testing --------------
    virtual public int takeDamage(int playerAttack){

        //Take the player's attack stat and have it affect boss's health
        health = health - playerAttack;
        AudioManager.Instance.PlaySound(_takeDamage);
        if (health < 0)
        {
            health = 0;
        }
        Debug.Log("Boss's Health: " + health);

        // --- Check to see if Boss Died ---
        if (health <= 0){
            //return health; // Uncomment if you want to run the test for boss health, uncommenting this will give unreachable code warning
            isAlive = false;
            dropBrain();
            Destroy(gameObject);
            counter.GetComponent<SpawnScript>().enemiesRemaining--;
            Debug.Log("You just killed a boss!!!");
            //health = 0;
            
        }
        return health;
    }
    virtual public int testTakeDamage(int playerAttack)
    {

        //Take the player's attack stat and have it affect boss's health
        health = health - playerAttack;
        //AudioManager.Instance.PlaySound(_takeDamage);
        if (health < 0)
        {
            health = 0;
        }
        Debug.Log("Boss's Health: " + health);
        
        return health;
    }
    private void dropBrain()
    {
        if (!isAlive)
        {
            GameObject newObj = Instantiate(brain, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
        }
    }
    // --------------- Returns the Boss's Current Health -----------------------
    public virtual int getHealth()
    {
        return health;
    }
    // ---------------- Returns the Boss's Current Attack Damage ---------------------
    public virtual int getDamage()
    {
        return attackDamage;
    }





}
