using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : Menu
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject HUD;
    

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
}
