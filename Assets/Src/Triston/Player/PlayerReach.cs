using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReach : MonoBehaviour
{

    private Collider2D collider;
    
    void Start()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //print("yo mister white im colliding");

        if (other.tag == "Breakable")
        {
            //print("jesse, this object is breakable");
        }

    }
}
