using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShop : Interactible
{

    private bool interacting = false;
    [SerializeField] private GameObject shopMenu;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "PLAYER")
        {
            interacting = CheckAct();
            if (interacting == true)
            {
                openShop();
                interacting = false;
            }
        }
    }

    public void openShop() {
        shopMenu.SetActive(true);   //open shop menu
        Time.timeScale = 0.0f;      //pause the game
    }
}
