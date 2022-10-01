using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSettings : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;

    public void SettingsMenu() {
        Debug.Log("bring up settings menu");
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
}
