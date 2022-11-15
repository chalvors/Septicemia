/*
 * Player.cs
 * Triston Hardcastle Peck
 * Damage calculation for player, attacking, healing and dying
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


/*
 * contains methods for player attacking, healing, damage calculation, and dying
 * 
 * member variables:
 * health - players current health
 * Alive - indicates if the player has died
 * stats - used for wrapping with the decorator
 * playerDamage - audio clip that plays upon dying
 * healthBar - component that syncs ui healthbar with player health
 * gameOverScreen - used to pull up the game over screen when dying
 * animator - the animator for the player
 * delay - the delay between attacks
 * attackBlocked - used to prevent the player from attacking if the delay has not passed
 * circleOrigin - origin of player attack circle collider
 * radius - radius of the player attack circle collider
 * BaseEnemy - enemy type for attacking
 * BaseBoss - ''
 * PistolEnemy - ''
 * RifleEnemy - ''
 * inSecretRoom - bool to stop enemies from spawning if player in secret room
 * DrBCMode - bool that if true makes player invincible
 */
public class Player : MonoBehaviour
{
    private int health;
    private int Alive = 1;
    PlayerStats stats;
    [SerializeField]
    private AudioClip playerDamage;
    [SerializeField]
    private GameObject healthBar;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float delay = 0.3f;
    private bool attackBlocked;
    [SerializeField]
    private Transform circleOrigin;
    [SerializeField]
    private float radius;

    public bool inSecretRoom = false;
    public bool DrBCMode;

    //check for key input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            attack();
        }
    }

    //initialize health, stats, and healthbar
    void Start()
    {
        health = 150;
        healthBar.GetComponent<HealthBar>().setMaxHealth(health);
        stats = new BaseStats();
    }

    //draw player attacks circle collider
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Vector3 position = circleOrigin == null ? Vector3.zero : circleOrigin.position;
        Gizmos.DrawWireSphere(position, radius);
    }

    //detect what enemies the player hit and deal damage to them
    public void DetectColliders()
    {

        foreach (Collider2D collider in Physics2D.OverlapCircleAll(circleOrigin.position, radius))
        {
            //Prevent the attack collider from registering the players collider
            if (collider.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                continue;
            }

            BaseEnemy enemy;
            BaseBoss boss;
            PistolEnemy pistol;
            RifleEnemy rifle;

            if (enemy = collider.GetComponent<BaseEnemy>())
            {
                enemy.takeDamage(stats.getDamage());
                Debug.Log("Dealt " + stats.getDamage() + " to " + collider.name);

            }

            if (boss = collider.GetComponent<BaseBoss>())
            {
                boss.takeDamage(stats.getDamage());
                Debug.Log("Dealt " + stats.getDamage() + " to " + collider.name);

            }

            if (pistol = collider.GetComponent<PistolEnemy>())
            {
                pistol.takeDamage(stats.getDamage());
                Debug.Log("Dealt " + stats.getDamage() + " to " + collider.name);

            }

            if (rifle = collider.GetComponent<RifleEnemy>())
            {
                rifle.takeDamage(stats.getDamage());
                Debug.Log("Dealt " + stats.getDamage() + " to " + collider.name);

            }
        }
    }

    //heal the player
    public void heal()
    {
        health = stats.getHealth();
        healthBar.GetComponent<HealthBar>().setHealth(health);
    }

    //deal damage to the player
    public int takeDamage(int Damage)
    {
        if(DrBCMode == true)
        {
            return health;
        }

        health = health - Damage;
        AudioManager.Instance.PlaySound(playerDamage);
        Debug.Log("Player Health: " + health);

        if (health <= 0)
        {
            die();
        }
        healthBar.GetComponent<HealthBar>().setHealth(health);
        return health;
    }

    //Player attack
    public void attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack"); //trigger the attack animation
        attackBlocked = true;
        StartCoroutine(delayAttack());
    }

    //used to delay the players attacking
    private IEnumerator delayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }

    //End the game when player dies
    void die()
    {
        Time.timeScale = 0f;
        Alive = 0;
        gameOverScreen.SetActive(true);
        print("YOU DIED! GAME OVER!");
    }

    //upgrade the players maximum health
    void decorateHealth()
    {
        stats = new DecorateHealth(stats);
    }

    //upgrade the players damage
    void decorateDamage()
    {
        stats = new DecorateDamage(stats);
    }

    public void BCModeToggle(bool toggle)
    {
        DrBCMode = toggle;
        Debug.Log("BC Mode ON");
    }

}


    

