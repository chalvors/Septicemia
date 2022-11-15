using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMaker : Interactible
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            isInteract = CheckAct();
            if (isInteract == true)
            {
                CreateCompanion();
                isInteract = false;
            }
        }
    }

    void CreateCompanion()
    {
        print("Companion Created");
    }
}
