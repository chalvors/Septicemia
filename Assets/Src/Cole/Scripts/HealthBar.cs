/*
* HealthBar.cs
* Cole Halvorson
* Controls the player health bar on the HUD
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* A class to control the health bar
*
* member variables:
* slider - GameObject for referencing the slider
*
* member functions:
* setMaxHealth() - sets maximum slider value
* setHealth() - sets current slider value
*/
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    //sets the maximum value on the health bar slider
    //int parameter for the health value
    public void setMaxHealth(int health) {
        slider.maxValue = health;
        slider.value = health;
    }

    //sets the current value on the health bar slider
    //int parameter for the health value
    public void setHealth(int health) {
        slider.value = health;
    }

}

