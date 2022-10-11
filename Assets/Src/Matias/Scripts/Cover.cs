using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : Interactible
{

    bool isInteract = false;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            isInteract = CheckAct();
            if (isInteract == true)
            {
                BreakWall();
                isInteract = false;
            }
        }
    }

    void BreakWall()
    {
        print("someday, this will be destroyed when you do that");
    }
}
