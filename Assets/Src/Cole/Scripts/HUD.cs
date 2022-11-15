//Cole Halvorson
//HUD.cs
//Unity
//Controls what is displayed on the HUD

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI brainsText;
    public TextMeshProUGUI roundText;

    public int testBrains = 0;

    void Update() {
        brainsText.text = GameManager.numBrains.ToString();
        roundText.text = "Round: " + GameManager.round.ToString();
    }

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