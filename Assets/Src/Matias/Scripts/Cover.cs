using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour
{

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "Player")
        {
            BreakWall();
        }
    }

    void BreakWall()
    {
        print("someday, this will be destroyed when you do that");
    }
}
