using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Manager_Test : MonoBehaviour
{
    public static int collectedCounter;
    public static int spawnedCounter;
    public TextMeshProUGUI collectedText;
    public TextMeshProUGUI spawnedText;

    private void FixedUpdate() {
        //Debug.Log(brainCounter);

        collectedText.text = "Collected: " + collectedCounter.ToString();
        spawnedText.text = "Spawned: " + spawnedCounter.ToString();

    }
}
