/*
* AudioManager.cs
* Kyle Hash
* Plays a sound on start
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Contains a function to play a sound on start
* 
* Start() - At the start when this script is called, it plays a sound
*/
public class PlaySoundOnStart : MonoBehaviour
{

    [SerializeField] private AudioClip _clip;
    // ----- Start is called before the first frame update ----
    // ----- Plays a sound clip at start --------------------
    void Start()
    {
        AudioManager.Instance.PlaySound(_clip);
    }

}
