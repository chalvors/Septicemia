using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private PauseMenu pausemenu;

   public static int round = 1;        //current round
   public static int numBrains = 0;  //number of brains collected by the player

   void Update()
   {
      if (Input.GetKey(KeyCode.Escape)) {
         //Debug.Log("escape");
         pausemenu.Pause();
      }
   }
}
