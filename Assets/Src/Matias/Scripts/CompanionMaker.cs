/*
 * CompanionMaker
 * Matias Crespo
 * Spawns in a new companion
 */
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class defines the behavior of the Companion Ball
 * 
 * compType - tells which type of companion is to be spawned
 * player - reference to the player object
 * zomDog - reference to the Zombie Dog prefab
 * zomBee - reference to the Zombie Bee prefab
 * zomGunman - reference to the Zombie Gunman prefab
 * isInteract - tells whether the player is interacting with an object
 */
public class CompanionMaker : Interactible
{
    [SerializeField]
    private int compType = 0;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject zomDog;
    [SerializeField]
    private GameObject zomBee;
    [SerializeField]
    private GameObject zomGunman;
    private bool isInteract = false;

    // while the player is in range, it can interact
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

    //creates one of three different companions
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

