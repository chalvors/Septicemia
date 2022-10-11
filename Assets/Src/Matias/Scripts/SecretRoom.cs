using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretRoom : MonoBehaviour
{
    int roomID;
    public bool Shop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SelectRoom()
    {
        if (Shop == false)
        {
            roomID = 0;
            Shop = true;
        }
        else 
        {
            roomID = Random.Range(1, 21);
        }
        return roomID;
    }
}
