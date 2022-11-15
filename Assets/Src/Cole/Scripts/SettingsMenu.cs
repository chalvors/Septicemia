/*
* SettingsMenu.cs
* Cole Halvorson
* Controls the settings menu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* A class to control the settings menu
* extends Menu
*
* member variables:
* mainMenu - GameObject for displaying the main menu
* settingsMenu - GameObject for displaying the settings menu
*
* member functions:
* back() - changes menus from settings to main
*/
public class SettingsMenu : Menu
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;

    //return to main menu from settings menu
    public void back() {
        Debug.Log("heading back to main menu from settings menu");
        changeMenu(settingsMenu, mainMenu);  //hide settings menu, open main menu
    }
}

