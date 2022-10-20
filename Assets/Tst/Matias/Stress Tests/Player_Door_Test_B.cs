using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Door_Test_B : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 player_direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
    }

    void Update()
    {

        player_direction = new Vector2(-1f, 0f).normalized;

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(player_direction.x * speed, player_direction.y * speed);
    }

}