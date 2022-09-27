using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 player_direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x_dir = Input.GetAxisRaw("Horizontal");
        float y_dir = Input.GetAxisRaw("Vertical");

        player_direction = new Vector2(x_dir, y_dir).normalized;

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(player_direction.x * speed, player_direction.y * speed);
    }
}
