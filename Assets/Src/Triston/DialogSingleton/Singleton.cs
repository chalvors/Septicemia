/*
 * Singleton.cs
 * Triston Hardcastle Peck
 * displays message prompting user to look for secret rooms
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * singleton class to display the opening help message
 * 
 * member variables:
 * instance - the instance of the singleton
 * dialog - the message that will be shown in the game
 */

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

        StartCoroutine(HideMessage());
    }


    public IEnumerator HideMessage()
    {
        
        yield return new WaitForSeconds(10);
        dialog.SetActive(false);
    }
}
