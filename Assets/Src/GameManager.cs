using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private GameObject pausemenu;

   public static int round = 1;        //current round
   public static int numBrains = 0;  //number of brains collected by the player

   void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pausemenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Start() {
        Time.timeScale = 0.0f;   //pause game on boot
    }

}
