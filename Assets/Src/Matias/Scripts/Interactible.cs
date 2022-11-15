/*
 * Interactible
 * Matias Crespo
 * Parent class for all interactible objects
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this class works as a parent to all interactible objects.
 */
public class Interactible : MonoBehaviour
{
    //checks if a player is pressing the interaction button
    public bool CheckAct()
    {
        if (Input.GetKey(KeyCode.K))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

