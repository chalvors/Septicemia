using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private PauseMenu pausemenu;

    // Start is called before the first frame update
   void Start()
   {

   }

    // Update is called once per frame
   void Update()
   {
      if (Input.GetKey(KeyCode.Escape)) {
         //Debug.Log("escape");
         pausemenu.Pause();
      }
   }
}
