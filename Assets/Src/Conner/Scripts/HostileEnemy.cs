using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostileEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            Attack();
        }
    }

    void Attack()
    {
        print("i'll get you for that in the full game!");
    }
}
