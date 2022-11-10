using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    //Enemy attack delay
    private float attackDelay;

    bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        upgradeCount = 1;
        stats = new EnemyStatsBasic();

        health = 50;
        damage = 0;

        //Find the player
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    private void FixedUpdate()
    {
        //
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= 3)
        {
            attackDelay += Time.deltaTime;

            //If the enemy is a RifleEnemy or PistolEnemy, shoot every 2 seconds
            if (attackDelay > 2 && (gameObject.tag == "RifleEnemy" || gameObject.tag == "PistolEnemy"))
            {
                attackDelay = 0;
                shoot();
            }
        }

        //Rotate the enemy to face the player when it is not moving
        if (player != null && distance <= 3)
        {
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            rotation *= Quaternion.Euler(90, 0, 0);
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }

        if (GameManager.round > upgradeCount)
        {
            wrapDamage();
            damage = GetDamage();

            wrapHealth();
            health = GetHealth();
            Debug.Log("Current PistolEnemy Health: " + health);
            Debug.Log("Current PistolEnemy Damage: " + damage);

            upgradeCount++;
        }
    }

    //Creates a bullet using a bullet prefab, spawn position. Quaternion.identity tells the bullet not to rotate after instantiation
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        AudioManager.Instance.PlaySound(gunfire);
        //Debug.Log("Shooting");
    }

    override protected void OnCollisionEnter2D(Collision2D collider)
    {
        //Pistol enemies will not deal damage on collision with the player
        return;
    }

    //Returns the damage
    public override int GetDamage()
    {
        return stats.GetDamage();
    }

    //Returns the health
    public override int GetHealth()
    {
        return stats.GetHealth();
    }
}
