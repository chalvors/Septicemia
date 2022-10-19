using Codice.CM.Common;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    // EnemyData data;
    //private GameObject player;
    //private Rigidbody2D rb;

    float maxSpeed = 2;

    void Update()
    {
        transform.Translate(Vector2.up * maxSpeed * Time.deltaTime);
    }
}
