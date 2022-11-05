using Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PistolEnemy : Enemy
{
    private GameObject player;

    //Holds a prefab for bullets fired by the enemies
    [SerializeField]
    private GameObject bullet;

    //Position that the bullet prefab will be placed
    [SerializeField]
    private Transform bulletPos;

    //Enemy attack delay
    private float attackDelay;

    bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        damage = 0;

        //Find the player
        player = GameObject.FindGameObjectWithTag("PLAYER");

        //Debug.Log(health);
        GetHealth();
        //Debug.Log(health);
    }

    private void FixedUpdate()
    {
        //
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= 10)
        {
            attackDelay += Time.deltaTime;

            //If the enemy is a RifleEnemy or PistolEnemy, shoot every 2 seconds
            if (attackDelay > 2 && (gameObject.tag == "RifleEnemy" || gameObject.tag == "PistolEnemy"))
            {
                attackDelay = 0;
                shoot();
            }
        }

        //Check if the enemy is moving
        //StartCoroutine(moveCheck());

        //Rotate the enemy to face the player when it is not moving
        if (player != null && distance <= 3)
        {
            Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            rotation *= Quaternion.Euler(90, 0, 0);
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
    }

    IEnumerator moveCheck()
    {
        //Get the initial position
        var p1 = transform.position;

        //Wait for a 10th of a second
        yield return new WaitForSeconds(0.1f);

        //Get the current position
        var p2 = transform.position;

        //Check if both positions are the same. If they are, then moving is false
        moving = (p1 != p2);
    }

    //Creates a bullet using a bullet prefab, spawn position. Quaternion.identity tells the bullet not to rotate after instantiation
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Debug.Log("Shooting");
    }

    //Returns the damage
    public override int GetDamage()
    {
        return damage;
    }

    //Returns the health
    public override int GetHealth()
    {
        return health;
    }
}
