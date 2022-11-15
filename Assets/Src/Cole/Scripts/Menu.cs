/*
* Menu.cs
* Cole Halvorson
* Provides basic functions for other menus
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* A class to provide common functions to menus
*
* member functions:
* quit() - exits the application
* changeMenu() - changes the active menu
*/

public class Menu : MonoBehaviour {
    
    //exits the application
    public virtual void quit() {
        Debug.Log("quitting the game");
        Application.Quit();
    }

    //changes active menu
    //two GameObject parameters, a 'from' menu and a 'to' menu
    public virtual void changeMenu(GameObject from, GameObject to) {
        from.SetActive(false);
        to.SetActive(true);
    }
}


