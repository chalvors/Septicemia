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

    [SerializeField]
    private GameObject brain;    // Boss item drop

    private GameObject BossObj = null;  // Used to get boss's location
    private float PosX = 0f;            // Boss's X coord
    private float PosY = 0f;            // Boss's Y coord
    private bool isAlive = true;        // Is the boss alive?


    private Rigidbody2D rb;
    private Vector2 movement; //Wont need this after getting pathfinding
    private CircleCollider2D bossCollider;

    [SerializeField]
    private GameObject Counter;

    [SerializeField] private AudioClip _takeDamage;



    // ----------------- Player Takes Damage From Boss ---------------------
    virtual protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject
   

            if (collider.GetComponent<Player>() != null)
            {
                collider.GetComponent<Player>().TakeDamage(attackDamage); // Calls Triston's TakeDamage function for the player
                
                //takeDamage(collider.GetComponent<Player>().attackstat);    // Calls my takeDamage function for the boss
                //canDealDamage = false;
                //StartCoroutine(DamageCooldown());
            }
            //Debug.Log("Damage dealt to the player!");
            //Debug.Log("Player health: " + collider.GetComponent<Player>().health);
        }
    }

    // ------------ Boss Takes Damage Dealt from the Player ------------------------
    // --------- Had to be a public function for bounds testing --------------
    virtual public void TakeDamage(int playerAttack){

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
            //dropBrain();
            Destroy(gameObject);
            Counter.GetComponent<SpawnScript>().enemiesRemaining--;
            Debug.Log("You just killed a boss!!!");
            
        }
        //return health;
    }
    private void dropBrain()
    {
        if (!isAlive)
        {
            BossObj = GameObject.FindGameObjectWithTag("BOSS");
            PosX = BossObj.transform.position.x;
            PosY = BossObj.transform.position.y;
            GameObject newObj = Instantiate(brain, new Vector2(PosX, PosY), Quaternion.identity);
        }
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
