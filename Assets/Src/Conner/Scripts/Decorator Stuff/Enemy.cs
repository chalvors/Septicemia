/*
* Enemy.cs
* Conner Mullins
* The superclass to the BaseEnemy, PistolEnemy, and RifleEnemy which holds all of their variables and virtual functions
*/
using System.Collections;
using UnityEngine;


/*
 *The stats of every enemy upon instantiation 
 */
public class EnemyStats
{

    //Returns the base damage
    public virtual int getDamage()
    {
        return 0;
    }

    //Returns the base health
    public virtual int getHealth()
    {
        return 30;
    }
}


/*
 * Takes the base damage and applies it to an object placeholder
 */
public class EnemyStatsUpgrade : EnemyStats
{
    //Since it is an EnemyStats object it can use EnemyStats functions
    public EnemyStats wrapee;

    //Apply EnemyStats getDamage to the placeholder
    public override int getDamage()
    {
        return wrapee.getDamage();
    }

    //Apply EnemyStats getDamage to the placeholder
    public override int getHealth()
    {
        return wrapee.getHealth();
    }
}


/*
 * Returns the object wrapped with a damage upgrade
 */
public class EnemyStatsUpgradeDamage : EnemyStatsUpgrade
{

    //A Constructor for EnemyStatsUpgradeDamage
    public EnemyStatsUpgradeDamage(EnemyStats wrapee)
    {
        this.wrapee = wrapee;
    }

    //Returns the placehold object with an increase in damage
    public override int getDamage()
    {
        return wrapee.getDamage() + 2;
    }
}


public class EnemyStatsUpgradeHealth : EnemyStatsUpgrade
{

    //A Constructor for EnemyStatsUpgradeHealth
    public EnemyStatsUpgradeHealth(EnemyStats wrapee)
    {
        this.wrapee = wrapee;
    }

    //Returns the placehold object with an increase in health
    public override int getHealth()
    {
        return wrapee.getHealth() + 5;
    }
}


/*
 * The superclass to the BaseEnemy, PistolEnemy, and RifleEnemy
 * 
 * member variables:
 * health - Total hitpoints that an enemy has
 * canDealDamage - Bool used as a cooldown to prevent enemies from dealing constant damage when colliding with the player
 * damage - How much health is removed from each attack by the enemy
 * counter - The EnemySpawner is placed here so that it can access the current round
 * takingDamage - AudioClip for when the enemies are damaged
 * brain - Prefab for an item that the enemies drop
 * death - AudioClip for when the enemies are destroyed
 */
public abstract class Enemy : MonoBehaviour
{
    //Set default values if data is not set
    protected int health = 50;
    protected bool canDealDamage = true;
    
    //This is public so that the pistol and rifle enemies can pass their damage to the bullets that they fire
    public int damage = 0;

    protected GameObject counter;

    [SerializeField]
    private GameObject brain;

    [SerializeField]
    private AudioClip takingDamage;

    [SerializeField]
    private AudioClip death;

    //
    virtual protected void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("PLAYER"))
        {
            //Deal Damage to Player if enemy collides with Player GameObject
            if(collider.gameObject.GetComponent<Player>() != null && canDealDamage)
            {
                Vector2 direction = (transform.position - collider.transform.position).normalized;
                gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 1600f, ForceMode2D.Impulse);
                collider.gameObject.GetComponent<Player>().takeDamage(damage);
                canDealDamage = false;
                StartCoroutine(damageCooldown());
            }
        }
    }

    //
    virtual protected IEnumerator damageCooldown()
    {
        yield return new WaitForSeconds(1f);
        canDealDamage = true;
    }

    //
    virtual public int takeDamage(int playerDamage)
    {
        health = health - playerDamage;
        Debug.Log("Enemy health: " + health);
        AudioManager.Instance.PlaySound(takingDamage);

        if (health <= 0)
        {
            AudioManager.Instance.PlaySound(death);
            GameObject newObj = Instantiate(brain, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
            Destroy(gameObject);
            counter.GetComponent<SpawnScript>().enemiesRemaining--;
            Debug.Log("Enemies remaining: " + counter.GetComponent<SpawnScript>().enemiesRemaining);
        }

        return health;
    }
    
    //
    public virtual int getHealth()
    {
        return health;
    }

    //
    public virtual int getDamage()
    {
        return damage;
    }
}

