using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveEnemy : MonoBehaviour
{
    public float health;
    public float damage;

    void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            TakeDamage(damage);
            Flee();
        }
    }

    public void Flee()
    {
        print("eep! run away! ahhhh!");
    }

    public float TakeDamage(float damage)
    {
        return health -= damage;
    }
}
