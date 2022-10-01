using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuStart : MonoBehaviour
{
    public GameObject mainMenu;

    public void StartGame() {
        Debug.Log("start game");
        mainMenu.SetActive(false);
    }
}
