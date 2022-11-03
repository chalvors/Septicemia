using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : Interactible
{

    bool isInteract = false;

    void Start()
    {
        
    }

    void OnTriggerStay2D(Collider2D interBox)
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
        //cool animation happens here
        Destroy(gameObject);
    }
}
