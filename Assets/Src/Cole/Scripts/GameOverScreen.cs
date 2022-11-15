/*
* GameOverScreen.cs
* Cole Halvorson
* Controls the game over screen
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* A class to control the game over screen
*
* member functions:
* restartGame() - restarts the game
*/
public class GameOverScreen : MonoBehaviour
{
    //restarts the game
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restarting the game");
    }
}

