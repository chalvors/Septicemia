using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Menu
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject HUD;

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Settings() {
        changeMenu(pauseMenu, settingsMenu);
    }

    public void Help() {
        changeMenu(pauseMenu, helpMenu);
    }

    public void Main() {
        changeMenu(pauseMenu, mainMenu);
        HUD.SetActive(false);
    }
}
