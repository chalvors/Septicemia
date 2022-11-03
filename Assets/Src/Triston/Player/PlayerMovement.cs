using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 player_direction;

    private float activeMoveSpeed;

    [SerializeField] private float dashSpeed;

    private float dashLength = 10f, dashcooldown = 20f;

    private float dashCounter;
    private float dashCoolCounter;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
    }

    void Update()
    {
        float x_dir = Input.GetAxisRaw("Horizontal");
        float y_dir = Input.GetAxisRaw("Vertical");

        player_direction = new Vector2(x_dir, y_dir).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0)
        {
            Debug.Log("delta time is " + Time.fixedDeltaTime);
            dashCounter -= Time.fixedDeltaTime;

            if(dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashcooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.fixedDeltaTime;
        }

    }

    void FixedUpdate()
    {
        dashSpeed = speed + 4;
        rb.velocity = new Vector2(player_direction.x * activeMoveSpeed, player_direction.y * activeMoveSpeed);

    }
}
