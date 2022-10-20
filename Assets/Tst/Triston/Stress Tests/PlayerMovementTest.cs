using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Vector2 player_direction;
    float x_dir;
    public TextMeshProUGUI Speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Move());
    }

    void Update()
    {

        player_direction = new Vector2(x_dir, 0f).normalized;

    }

    public IEnumerator Move()
    {
        float x = 0f;
        while(x == 0f)
        {
            x_dir = -1f;
            yield return new WaitForSeconds(1f);
            x_dir = 1f;
            yield return new WaitForSeconds(1f);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(player_direction.x * speed, player_direction.y * speed);
        Speed.text = "Speed: " + speed.ToString();
    }

    public float SpeedUpgrade()
    {
        speed = speed + 1;
        return speed;
    }
}
