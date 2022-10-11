using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject helpMenu;
    [SerializeField] private GameObject HUD;
    

    public void StartGame() {
        Debug.Log("Starting Game");
        mainMenu.SetActive(false);
        Time.timeScale = 1.0f;   //unpause game on start
        HUD.SetActive(true);
    }

    public void Settings() {
        Debug.Log("Starting Game");
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Help() {
        Debug.Log("Starting Game");
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }

    public void Start() {
        Time.timeScale = 0.0f;   //pause game on boot
    }
}
