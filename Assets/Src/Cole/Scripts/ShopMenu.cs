using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    public TextMeshProUGUI brainCounter;
    public void decreaseBrains() {
        Debug.Log("decreasing brains");
    }

    public void Update() {
        //brainCounter.text = "Brains: " + BrainCollector.numBrains;
    }
}
