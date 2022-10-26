using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretRoom : Interactible
{
    int roomID;
    bool isInteract = false;
    public bool Shop = false;
    // Start is called before the first frame update
    void Start()
    {
        roomID = SelectRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D interBox)
    {
        if (interBox.tag == "PLAYER")
        {
            isInteract = CheckAct();
            if (isInteract == true)
            {
                GoToRoom(roomID);
                isInteract = false;
            }
        }
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
            roomID = Random.Range(1, 15);
        }
        return roomID;
    }

    void GoToRoom(int room)
    {
        string ID = "SR" + room;
        SceneManager.LoadScene(ID);
    }
}
