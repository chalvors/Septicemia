using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI brainCounter;
    [SerializeField] private GameObject shopMenu;
    
    Player p1 = new Player();
    PlayerMovement pm1 = new PlayerMovement();

    public void upgradeHealth(int cost) {
        if (cost <= GameManager.numBrains) {  //if have enough brains
            p1.decorateHealth();              //upgrade player health
            GameManager.numBrains -= cost;    //subtract cost from brains
        } else {
            Debug.Log("Not enough brains!");
        }
    }

    public void upgradeDamage(int cost) {
        if (cost <= GameManager.numBrains) {  //if have enough brains
            p1.decorateDamage();              //upgrade player health
            GameManager.numBrains -= cost;    //subtract cost from brains
        } else {
            Debug.Log("Not enough brains!");
        }
    }

    public void upgradeSpeed(int cost) {
        if (cost <= GameManager.numBrains) {  //if have enough brains
            pm1.decorateSpeed();              //upgrade player health
            GameManager.numBrains -= cost;    //subtract cost from brains
        } else {
            Debug.Log("Not enough brains!");
        }
    }

    public void exitShop() {
        shopMenu.SetActive(false);  //hide shop menu
        Time.timeScale = 1.0f;      //resume the game
    }

    public void Update() {
        brainCounter.text = "Brains: " + GameManager.numBrains;   //update brain counter
    }
}
