/*
* AudioManager.cs
* Kyle Hash
* Sinlgeton Pattern for managing audio
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


/*
* Contains basic functions for managing audio
* 
* Awake() - Creates an instance of the AudioManger if one doesn't already exist
* PlaySound() -  Basic function to play whatever sound clip is referenced 
*/
public class AudioManager : MonoBehaviour
{
    //--- Creating a single instance enforces a singleton pattern ---
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;
    // Start is called before the first frame update

    // ----------- Creates an instance of the AudioManger if one doesn't already exist ----------------------
    void Awake()
    {
      if (Instance == null) // If there is no instance, create one that wont be destroyed
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // There is already an instance
        {
            Destroy(gameObject);
        }
    }

    // ------------- Function for other people to call to play a sound ----------------------
   public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
    // ------------- Function for main menu slider to change master volume ----------------------
    public void changeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
