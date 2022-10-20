using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool EnteredTrigger;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TestBoss"))
        {
            EnteredTrigger = true;
            Debug.Log("Yep, enemy is out! **********************************************************");
        }
    }
}
