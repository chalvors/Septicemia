using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHelp : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject helpMenu;

    public void HelpMenu() {
        Debug.Log("bring up settings menu");
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }
}
