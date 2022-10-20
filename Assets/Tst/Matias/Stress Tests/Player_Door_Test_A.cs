using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_Door_Test_A : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 player_direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 5f;
        print("A Start");
    }

    void Update()
    {
        
        player_direction = new Vector2(1f, 0f).normalized;
        print("A Update");

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(player_direction.x * speed, player_direction.y * speed);
        print("A Fixed Update");
    }

}