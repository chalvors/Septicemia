/*
 * PlayerMovement.cs
 * Triston Hardcastle Peck
 * Implements the player characters movement system and dashing ability
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deals with movement of the player and manages the dash ability
 * 
 * member variables:
 * speed-the players base speed
 * rb - the players rigidbody component
 * player_direction - the players movement direction
 * activeMoveSpeed - The Players current move speed
 * dashSpeed - The players speed while dashing
 * rotationSpeed - how quickly the player rotates while changing direction
 * dashLength - The length of the dash
 * dashCooldown - the length of the time between dashes
 * dashCounter - helper variable to keep track of dash time
 * dashCoolCounter - helper variable to keep track of dash cooldown time
 */
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Rigidbody2D rb;
    private Vector2 player_direction;
    private float activeMoveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float rotationSpeed;
    private float dashLength = 0.5f, dashcooldown = 2f;
    private float dashCounter;
    private float dashCoolCounter;


    //initialize move speed and player rigidbody
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
    }

    //use keyboard input to determine player movement direction, upkeep dash ability timer and speed
    void Update()
    {
        //input for player direction
        float x_dir = Input.GetAxisRaw("Horizontal"); 
        float y_dir = Input.GetAxisRaw("Vertical");

        player_direction = new Vector2(x_dir, y_dir).normalized;

        //check for dash key press
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        //keeps track of the dash length
        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashcooldown;
            }
        }

        //keeps track of dash cooldown
        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }

    //set player velocity, physics, and rotation speed
    void FixedUpdate()
    {
        dashSpeed = speed + 4;
        rb.velocity = new Vector2(player_direction.x * activeMoveSpeed, player_direction.y * activeMoveSpeed);
        
        if (player_direction != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, player_direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void decorateSpeed()
    {
        speed = speed+1;
        activeMoveSpeed = speed;
    }
}


