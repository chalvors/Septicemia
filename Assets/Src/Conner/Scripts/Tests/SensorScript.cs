/*
* SensorScript.cs
* Conner Mullins
* A script for a sensor that checks to see if a TestEnemy has escaped the map
*/
using UnityEngine;


public class SensorScript : MonoBehaviour
{
    public bool EnteredTrigger;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TestEnemy")) {
            EnteredTrigger = true;
            Debug.Log("Yep, enemy is out! **********************************************************");
        }
    }
}
