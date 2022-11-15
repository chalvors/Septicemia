//Cole Halvorson
//MainMenu.cs
//Unity
//Controls the main menu
//Extends Menu.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject videoPlayer;

    private int idleTime = 0;
    [SerializeField] private int timeOut;
    
    public void StartGame() {
        changeMenu(mainMenu, HUD);  //change from main menu to HUD
        Time.timeScale = 1.0f;   //unpause game on start
    }

    public void Settings() {
        changeMenu(mainMenu, settingsMenu);  //change from main menu to settings menu
    }

    public void Help() {
        changeMenu(mainMenu, helpMenu);  //change from main menu to help menu
    }

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
