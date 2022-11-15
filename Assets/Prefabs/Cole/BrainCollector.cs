using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCollector : MonoBehaviour
{
    //Total number of brains collected
    //public static int numBrains = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the object is a brain
        if (collision.CompareTag("Brain"))
        {
            //Destroy it and add to the brain counter
            Destroy(collision.gameObject);
            GameManager.numBrains++;
            Debug.Log("Brains: " + GameManager.numBrains);
        }
    }
}