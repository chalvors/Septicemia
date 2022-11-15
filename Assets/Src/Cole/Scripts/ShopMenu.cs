/*
* ShopMenu.cs
* Cole Halvorson
* Controls the shop menu
*/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
* A class to control the shop menu
*
* member variables:
* brainCounter - TextMeshProUGUI Object for displaying the player's current brains
* shopMenu - GameObject for displaying the shop menu
* p1 - Player class object for upgrading the player's health and damage
* pm1 - PlayerMovement class object for upgrading the player's speed
*
* member functions:
* upgradeHealth() - upgrades the player's health
* upgradeDamage() - upgrades the player's damage
* upgradeSpeed() - upgrades the player's speed
* exitShop() - closes the shop menu, resumes the game
* Update() - updates brain counter
*/
public class ShopMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI brainCounter;
    [SerializeField] private GameObject shopMenu;
    
    Player p1 = new Player();
    PlayerMovement pm1 = new PlayerMovement();

    //upgrades player health
    //int parameter of the cost of the upgrade
    public void upgradeHealth(int cost) {
        if (cost <= GameManager.numBrains) {  //if have enough brains
            p1.decorateHealth();              //upgrade player health
            GameManager.numBrains -= cost;    //subtract cost from brains
        } else {
            Debug.Log("Not enough brains!");
        }
    }

    //upgrades player damage
    //int parameter of the cost of the upgrade
    public void upgradeDamage(int cost) {
        if (cost <= GameManager.numBrains) {  //if have enough brains
            p1.decorateDamage();              //upgrade player damage
            GameManager.numBrains -= cost;    //subtract cost from brains
        } else {
            Debug.Log("Not enough brains!");
        }
    }

    //upgrades player speed
    //int parameter of the cost of the upgrade
    public void upgradeSpeed(int cost) {
        if (cost <= GameManager.numBrains) {  //if have enough brains
            pm1.decorateSpeed();              //upgrade player speed
            GameManager.numBrains -= cost;    //subtract cost from brains
        } else {
            Debug.Log("Not enough brains!");
        }
    }

    //disables the shop menu, resumes the game
    public void exitShop() {
        shopMenu.SetActive(false);  //hide shop menu
        Time.timeScale = 1.0f;      //resume the game
    }

    //keeps brain counter up to date
    public void Update() {
        brainCounter.text = "Brains: " + GameManager.numBrains;   //update brain counter
    }
}

