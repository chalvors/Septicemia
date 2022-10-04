using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject helpMenu;

    public void StartGame() {
        Debug.Log("Starting Game");
        mainMenu.SetActive(false);
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
}