using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMaker : Interactible
{
    [SerializeField]
    int compType = 0;
    
    bool isInteract = false;

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
        Destroy(gameObject);

        if(compType == 1)
        {
            //spawn Zombie Dog
        }
        else if (compType == 2)
        {
            //spawn ZomBee
        }
        else if (compType == 3)
        {
            //spawn Zombie Gunman
        }
    }
}
