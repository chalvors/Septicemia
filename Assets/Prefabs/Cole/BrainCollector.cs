using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainCollector : MonoBehaviour
{
    //Total number of brains collected
    private float brain = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the object is a brain
        if (collision.CompareTag("Brain"))
        {
            //Destroy it and add to the brain counter
            Destroy(collision.gameObject);
            brain++;
            Debug.Log("Brains: " + brain);
        }
    }
}