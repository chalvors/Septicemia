using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenu;

    void Update() {
        if ( Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        gameIsPaused = true;
    }
}
