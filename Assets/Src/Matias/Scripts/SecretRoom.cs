/*
 * SecretRoom
 * Matias Crespo
 * Teleports player between the main play area and the secret rooms
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class defines the behavior of secret doors
 * 
 * roomID - ID number of destination door
 * opening - audio clip for door opening
 * destination - reference to the destination door
 * player - reference to the player
 * roomPosition - position of the destination door
 * fullID - full name of destination door
 * isInteract - tells whether the player is interacting with an object
 * delay - tells whether the player is in a secret room
 * shop - tells whether the player shop has been placed
 */
public class SecretRoom : Interactible
{
    [SerializeField]
    public int roomID = 0;
    [SerializeField]
    private AudioClip opening; 
    private GameObject destination;
    private GameObject player;
    private Vector3 roomPosition;
    private string fullID;
    private bool isInteract = false;
    private bool delay = false;

    public bool shop = false;

    // Start is called before the first frame update
    void Start()
    {
        fullID = "Secret Door " + roomID;
        destination = GameObject.Find(fullID);
        roomPosition = destination.transform.position;
        player = GameObject.FindWithTag("PLAYER");
        player.GetComponent<Player>().inSecretRoom = false;
    }

    // while the player is in range, it can interact
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

    //selects random ID (remnant of old level generation)
    public int SelectRoom()
    {
        if (shop == false)
        {
            roomID = 0;
            shop = true;
        }
        else 
        {
            roomID = Random.Range(1, 15);
        }
        return roomID;
    }

    // sends player to destination door
    void GoToRoom(Vector3 room)
    {
        player.transform.position = room;
        player.GetComponent<Player>().inSecretRoom = !player.GetComponent<Player>().inSecretRoom;
    }

    //delays round timer while in a secret room
    IEnumerator switchDelay()
    {
        isInteract = false;
        //player.GetComponent<Player>().inSecretRoom = !player.GetComponent<Player>().inSecretRoom;
        yield return new WaitForSeconds(.5f);
        GoToRoom(roomPosition);
        delay = false;
    }
}

