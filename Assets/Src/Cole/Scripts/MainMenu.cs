/*
* MainMenu.cs
* Cole Halvorson
* Controls the main menu
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* A class to control the main menu
* extends Menu
*
* member variables:
* mainMenu - GameObject for displaying the main menu
* settingsMenu - GameObject for displaying the settings menu
* helpMenu - GameObject for displaying the help menu
* HUD - GameObject for displaying the HUD
* videoPlayer - GameObject for displaying the demo video
* timeOut - how long before the demo video will start playing
* idleTime - counter for how long the user has been idle in the main menu for 
*
* member functions:
* startGame() - changes the menu from the main menu to the HUD, unpauses the game
* settings() - opens the settings menu
* help() - opens the help menu
* FixedUpdate() - used to display the demo video
*/
public class MainMenu : Menu
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject videoPlayer;
    [SerializeField] private int timeOut;
    private int idleTime = 0;
    
    //starts the game
    public void startGame() {
        changeMenu(mainMenu, HUD);  //change from main menu to HUD
        Time.timeScale = 1.0f;   //unpause game on start
    }

    //opens the settings menu
    public void settings() {
        changeMenu(mainMenu, settingsMenu);  //change from main menu to settings menu
    }

    //opens the help menu
    public void help() {
        changeMenu(mainMenu, helpMenu);  //change from main menu to help menu
    }

    //controls the demo video
    public void FixedUpdate() {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));  //detect mouse input

        if (mouseInput.magnitude == 0 && !Input.anyKey) {  //increment time while user is idle
            idleTime++;
        } 
        else {  //restart time and stop video
            Debug.Log("stopping video");
            idleTime = 0;
            videoPlayer.SetActive(false);
            mainMenu.SetActive(true);
        }

        if (idleTime >= timeOut) {  //play video if user is idle for too long
            Debug.Log("playing video");
            videoPlayer.SetActive(true);
            mainMenu.SetActive(false);
        }
    }
}

