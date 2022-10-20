using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSensor : MonoBehaviour
{
    public bool EnteredTrigger;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PLAYER"))
        {
            EnteredTrigger = true;
            Debug.Log("Yo mister White, the player is out of bounds");
        }
    }
}
