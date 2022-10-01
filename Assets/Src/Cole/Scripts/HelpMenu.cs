using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject helpMenu;

    public void Back() {
        Debug.Log("heading back to main menu from help menu");
        helpMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
