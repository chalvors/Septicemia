using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public int num_brains = 0;

    void Update() {
        
    }

    public int purchase(int cost) {
        if (cost <= num_brains) {
            num_brains -= cost;
        } 
        else {
            Debug.Log("not enough brains");
        }
        return num_brains;
    }
}
