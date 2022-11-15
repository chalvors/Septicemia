using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CompanionMaker : Interactible
{
    [SerializeField]
    int compType = 0;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject zomDog;

    [SerializeField]
    private GameObject zomBee;

    [SerializeField]
    private GameObject zomGunman;

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
        Vector3 spawn = new Vector3(0, 0, 0);

        Destroy(gameObject);

        if(compType == 1)
        {
            GameObject zom1 = Instantiate(zomDog, spawn, Quaternion.identity);
            AIDestinationSetter aiDestSetter = zom1.GetComponent<AIDestinationSetter>();
            aiDestSetter.target = player.transform;
        }
        else if (compType == 2)
        {
            GameObject zom2 = Instantiate(zomBee, spawn, Quaternion.identity);
            AIDestinationSetter aiDestSetter = zom2.GetComponent<AIDestinationSetter>();
            aiDestSetter.target = player.transform;
        }
        else if (compType == 3)
        {
            GameObject zom3 = Instantiate(zomGunman, spawn, Quaternion.identity);
            AIDestinationSetter aiDestSetter = zom3.GetComponent<AIDestinationSetter>();
            aiDestSetter.target = player.transform;
        }
    }
}
