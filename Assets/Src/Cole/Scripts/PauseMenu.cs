using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.SetActive(true);
            Pause();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.SetActive(false);
            Debug.Log("back to the game!");
        }
    }

    public void Pause()
    {
        Debug.Log("this will be the pause menu in the final game");
    }
}
