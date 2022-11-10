using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    // to have the camera follow the player, we of course need to find the player.
    private GameObject Player;

    // this will be the limits in which we want our camera to stay.
    // we don't want the camera following the player if it falls off screen!
    [SerializeField]
    public float x_min, x_max, y_min, y_max;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        // Mathf.Clamp() -- returns the given value if it falls between the min and max.

        // find the player's current x position...
        // ... and see if it exists between x_min and x_max.
        float x = Mathf.Clamp(Player.transform.position.x, x_min, x_max);

        // find the player's current y position...
        // ... and see if it exists between y_min and y_max.
        float y = Mathf.Clamp(Player.transform.position.y, y_min, y_max);


        // we use gameObject instead of GameObject as we are referencing our camera.
        // this will move the camera to the player's xyz position!
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
