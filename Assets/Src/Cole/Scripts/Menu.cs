using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Quit() {
        Debug.Log("quitting the game");
        Application.Quit();
    }

    public void changeMenu(GameObject from, GameObject to) {
        from.SetActive(false);
        to.SetActive(true);
    }
}
