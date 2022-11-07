using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    //--- Creating a single instance enforces a singleton pattern ---
    public static AudioManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;
    // Start is called before the first frame update
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

   public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
}
