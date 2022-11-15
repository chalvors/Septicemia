using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowboyHat : Interactible
{
    bool isInteract = false;

    [SerializeField]
    private GameObject hat;

    [SerializeField]
    private AudioClip cowboySong;

    private SpriteRenderer hatSprite;
    // Start is called before the first frame update
    void Start()
    {
        hatSprite = hat.GetComponent<SpriteRenderer>();
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

        hatSprite.enabled = true;
        //AudioManager.Instance.Stop();
        AudioManager.Instance.PlaySound(cowboySong);
    }
}
