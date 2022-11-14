/*
* PistolEnemy.cs
* Conner Mullins
* The script that determines the behavior of the PistolEnemy
*/
using System.Collections;
using UnityEngine;


//These are the base stats of the pistol enemy, which override the values from EnemyStats
public class EnemyPistolStats : EnemyStats
{
    //Base damage for the pistol enemy
    public override int getDamage()
    {
        return 15;
    }

    //Base health for the pistol enemy
    public override int getHealth()
    {
        return 30;
    }
}


/*
 * This is the pistol enemy subclass of Enemy.cs, which determines the stats of all pistol enemies
 * 
 * member variables:
 * stats - Placeholder for the damage and health stats. This is what is decorated by my decorator pattern
 * upgradeCount - Keeps track of how many upgrades the enemies have had
 */
public class PistolEnemy : Enemy
{
    EnemyStats stats;
    int upgradeCount;

    private void wrapDamage()
    {
        stats = new EnemyStatsUpgradeDamage(stats);
    }

    private void wrapHealth()
    {
        stats = new EnemyStatsUpgradeHealth(stats);
    }

    private GameObject player;

    //Holds a prefab for bullets fired by the enemies
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private AudioClip gunfire;

    //Position that the bullet prefab will be placed
    [SerializeField]
    private Transform bulletPos;

    //How much time the enemy waits before attacking
    [SerializeField]
    private float attackDelay;

    //Time that has passed between attacks
    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("EnemySpawner");
        upgradeCount = 1;
        stats = new EnemyPistolStats();

        damage = getDamage();
        health = getHealth();

        //Find the player
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    private void FixedUpdate()
    {
        //Check how far the enemy is from the player
        float distance = Vector2.Distance(transform.position, player.transform.position);

        //If the player is within 3 units...
        if (distance <= 3)
        {
            //Begin charging the attack
            attackTimer += Time.deltaTime;

            //If the enemy is a PistolEnemy, shoot after having waited the required time between attacks
            if (attackTimer > attackDelay && (gameObject.tag == "RifleEnemy" || gameObject.tag == "PistolEnemy"))
            {
                StartCoroutine(shoot());
            }
        }

        //Rotate the enemy to face the player when it is not moving
        if (player != null && distance <= 3)
        {
            
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
           
            //Adds 90 degrees to the rotation in order to make the enemy face the correct direction
            rotation *= Quaternion.Euler(90, 0, 0);


            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            
            
        }

        if (GameManager.round > upgradeCount)
        {
            wrapDamage();
            damage = getDamage();

            wrapHealth();
            health = getHealth();
            Debug.Log("Current PistolEnemy Health: " + health);
            Debug.Log("Current PistolEnemy Damage: " + damage);

            upgradeCount++;
        }
    }

    //Creates a bullet using a bullet prefab, spawn position. Quaternion.identity tells the bullet not to rotate after instantiation
    IEnumerator shoot()
    {
        attackTimer = 0;
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        AudioManager.Instance.PlaySound(gunfire);
        yield return null;
    }

    override protected void OnCollisionStay2D(Collision2D collider)
    {
        //Pistol enemies will not deal damage on collision with the player
        return;
    }

    //Returns the damage
    public override int getDamage()
    {
        return stats.getDamage();
    }

    //Returns the health
    public override int getHealth()
    {
        return stats.getHealth();
    }
}

