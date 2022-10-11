using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoom : MonoBehaviour
{
    int roomID;
    bool Shop = false;
    Random rnd = new Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectRoom()
    {
        if (Shop = false)
        {
            roomID = 0;
            Shop = true;
        }
        else 
        {
            roomID = rnd.Next(1, 20);
        }
        return roomID;
    }
}
