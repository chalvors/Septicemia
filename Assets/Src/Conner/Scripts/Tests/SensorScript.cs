using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorScript : MonoBehaviour
{
    public bool EnteredTrigger;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TestEnemy")) {
            EnteredTrigger = true;
            Debug.Log("Yep, enemy is out! **********************************************************");
        }
    }
}
