/*
* PauseMenu.cs
* Cole Halvorson
* Controls the pause menu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* A class to control the pause menu
* extends Menu
*
* member variables:
* pauseMenu - GameObject for displaying the pause menu
* settingsMenu - GameObject for displaying the settings menu
* helpMenu - GameObject for displaying the help menu
* mainMenu - GameObject for displaying the main menu
* HUD - GameObject for displaying the HUD
*
* member functions:
* resume() - resumes the game
* settings() - opens the settings menu
* help() - opens the help menu
* main() - opens the main menu, disables the HUD
*/
public class PauseMenu : Menu
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject HUD;

    //unpauses the game
    public void resume() {
        pauseMenu.SetActive(false);  //hide pause menu
        Time.timeScale = 1.0f;       //resume game
    }

    //opens the settings menu
    public void settings() {
        changeMenu(pauseMenu, settingsMenu);  //hide pause menu, show settings menu
    }

    //opens the help menu
    public void help() {
        changeMenu(pauseMenu, helpMenu);  //hide pause menu, show help menu
    }

    //opens the main menu
    public void main() {
        changeMenu(pauseMenu, mainMenu);  //hide pause menu, show main menu
        HUD.SetActive(false);             //hide HUD
    }
}

