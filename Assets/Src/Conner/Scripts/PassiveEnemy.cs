using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            Flee();
        }
    }

    void Flee()
    {
        print("eep! run away! ahhhh!");
    }
}
