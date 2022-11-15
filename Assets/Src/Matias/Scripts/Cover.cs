using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Cover : Interactible
{

    bool isInteract = false;

    [SerializeField]
    private AudioClip breaking;

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
        AudioManager.Instance.PlaySound(breaking);
        Destroy(gameObject);
        AstarPath.active.Scan();
    }
}
