/*
* SensorScript.cs
* Conner Mullins
* A script for a sensor that checks to see if a TestEnemy has escaped the map
*/
using UnityEngine;


/*
 * This is the sensor script, which checks to see if the test enemy collides with this object
 * 
 * member variables:
 * enteredTrigger - A bool that becomes true when the enemy collides with this object
 */
public class SensorScript : MonoBehaviour
{
    public bool enteredTrigger;

    public void OnTriggerEnter2D(Collider2D other)
    {
        //If the test enemy collides with the sensor, they have escaped the map
        if (other.CompareTag("TestEnemy")) {
            enteredTrigger = true;
            Debug.Log("Yep, enemy is out! **********************************************************");
        }
    }
}

