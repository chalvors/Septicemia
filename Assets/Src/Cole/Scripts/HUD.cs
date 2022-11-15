/*
* HUD.cs
* Cole Halvorson
* Controls the HUD
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
* A class to control the HUD
*
* member variables:
* brainsText - TextMeshProUGUI object for displaying the number of brains the player has collected
* roundText - TextMeshProUGUI object for displaying the current round
*
* member functions:
* Update() - displays counters
* purchase() - test function for boundary test
*/
public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI brainsText;
    [SerializeField] private TextMeshProUGUI roundText;

    public int testBrains = 0;

    //displays brains and round counters
    void Update() {
        brainsText.text = GameManager.numBrains.ToString();  //display number of brains
        roundText.text = "Round: " + GameManager.round.ToString();  //display current round
    }

    //test function for shop boundary test
    public int purchase(int cost) {  
        if (cost <= testBrains) {
            testBrains -= cost;
        } 
        else {
            Debug.Log("not enough brains");
        }
        return testBrains;
    }
}

