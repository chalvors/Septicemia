/*
 * CowboyHat
 * Matias Crespo
 * Activates Cowboy Mode upon interaction
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class defines the behavior of the cowboy hat
 * 
 * hat - references the Cowboy Hat object
 * cowboySong - audio clip of the song for Cowboy Mode
 * isInteract - tells whether the player is interacting with an object
 * hatSprite - reference to the sprite renderer of Cowboy Hat
 */
public class CowboyHat : Interactible
{
    [SerializeField]
    private GameObject hat;
    [SerializeField]
    private AudioClip cowboySong;
    private bool isInteract = false;
    private SpriteRenderer hatSprite;

    // Start is called before the first frame update
    void Start()
    {
        hatSprite = hat.GetComponent<SpriteRenderer>();
    }

    // while the player is in range, it can interact
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

    //enables cowboy hat and plays cowboy song
    void CowboyMode()
    {
        Destroy(gameObject);
        hatSprite.enabled = true;
        //AudioManager.Instance.Stop();
        AudioManager.Instance.PlaySound(cowboySong);
    }
}

