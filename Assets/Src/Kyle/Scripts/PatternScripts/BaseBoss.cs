using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoss : Bosses
{
    // Start is called before the first frame update
    void Start()
    {
        //Initialize the Base Boss
        health = 100;
        attackDamage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
