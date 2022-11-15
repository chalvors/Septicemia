//Cole Halvorson
//SettingsMenu.cs
//Unity
//Controls the settings menu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;

    public void Back() {
        Debug.Log("heading back to main menu from settings menu");
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
