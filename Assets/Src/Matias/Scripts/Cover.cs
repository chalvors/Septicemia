/*
 * Cover
 * Matias Crespo
 * Destructible Cover
 */
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class defines the behavior of breakable cover objects
 * 
 * member vairables:
 * breaking - audio clip for the cover breaking
 * isInteract - tells whether the player is interacting with an object
 */
public class Cover : Interactible
{
    [SerializeField]
    private AudioClip breaking;
    private bool isInteract = false;

    // while the player is in range, it can interact
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

    // destroys wall and resets the pathfinding
    void BreakWall()
    {
        //cool animation happens here
        AudioManager.Instance.PlaySound(breaking);
        Destroy(gameObject);
        AstarPath.active.Scan();
    }
}

