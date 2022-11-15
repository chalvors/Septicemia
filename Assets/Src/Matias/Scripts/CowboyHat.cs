using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyHat : Interactible
{
    bool isInteract = false;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private AudioClip cowboySong;

    private CowboyHat hat;
    // Start is called before the first frame update
    void Start()
    {
        hat = player.GetComponent<CowboyHat>();
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
                CowboyMode();
                isInteract = false;
            }
        }
    }

    void CowboyMode()
    {
        print("YeeHaw!!!");

        hat.enabled = true;
        //AudioManager.Instance.Stop();
        AudioManager.Instance.PlaySound(cowboySong);
    }
}
