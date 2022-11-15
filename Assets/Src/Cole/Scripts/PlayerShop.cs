/*
* PlayerShop.cs
* Cole Halvorson
* Allows for player interaction with the shop
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* A class to control the player's interaction with the shop
* extends Interactible
*
* member variables:
* shopMenu - GameObject for displaying the shop menu
* interacting - boolean for telling if the player is interacting with the shop or not
*
* member functions:
* OnTriggerStay2D() - used to tell if the player is close enough and is interacting with the shop
* openShop() - opens the shop menu, pauses the game
*/
public class PlayerShop : Interactible
{
    [SerializeField] private GameObject shopMenu;
    private bool interacting = false;

    //detects player collision with shop
    //Collider2D parameter for whatever collides with the shop
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "PLAYER")  //if the player collides with the shop
        {
            interacting = CheckAct();   
            if (interacting == true)  //if the player hits the interact key
            {
                openShop();           
                interacting = false;
            }
        }
    }

    //opens the shop menu
    public void openShop() {
        shopMenu.SetActive(true);   //open shop menu
        Time.timeScale = 0.0f;      //pause the game
    }
}

