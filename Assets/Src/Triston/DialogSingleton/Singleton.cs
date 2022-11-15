/*
 * Singleton.cs
 * Triston Hardcastle Peck
 * displays message prompting user to look for secret rooms
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;
    public GameObject dialog;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(dialog);
        }
    }


    public void HideMessage()
    {
        dialog.SetActive(false);
    }
}