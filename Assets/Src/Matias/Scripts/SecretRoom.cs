using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretRoom : Interactible
{
    [SerializeField]
    public int roomID = 0;

    [SerializeField]
    private AudioClip opening; 

    private GameObject destination;
    private GameObject player;
    Vector3 roomPosition;
    string fullID;
    bool isInteract = false;
    public bool Shop = false;
    private bool delay = false;
    // Start is called before the first frame update
    void Start()
    {
        fullID = "Secret Door " + roomID;
        destination = GameObject.Find(fullID);
        roomPosition = destination.transform.position;
        player = GameObject.FindWithTag("PLAYER");
        player.GetComponent<Player>().inSecretRoom = false;
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
            if (isInteract == true && delay == false && !SpawnScript.Instance.enemiesSpawning)
            {
                delay = true;
                AudioManager.Instance.PlaySound(opening);
                StartCoroutine(switchDelay());
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

    void GoToRoom(Vector3 room)
    {
        player.transform.position = room;
    }

    IEnumerator switchDelay()
    {
        isInteract = false;
        player.GetComponent<Player>().inSecretRoom = !player.GetComponent<Player>().inSecretRoom;
        yield return new WaitForSeconds(.5f);
        GoToRoom(roomPosition);
        delay = false;
    }
}
