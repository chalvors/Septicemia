using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HUD : MonoBehaviour
{
    public int numBrains = 0;
    public TextMeshProUGUI brainsText;
    public TextMeshProUGUI roundText;

    void Update() {
        brainsText.text = numBrains.ToString();
        roundText.text = "Round: " + GameManager.round.ToString();
    }

    public int purchase(int cost) {
        if (cost <= numBrains) {
            numBrains -= cost;
        } 
        else {
            Debug.Log("not enough brains");
        }
        return numBrains;
    }
}