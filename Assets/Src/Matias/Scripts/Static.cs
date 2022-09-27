using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static : MonoBehaviour
{

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            DoNotBreak();
        }
    }

    void DoNotBreak()
    {
        print("you can't destroy this!");
    }
}
