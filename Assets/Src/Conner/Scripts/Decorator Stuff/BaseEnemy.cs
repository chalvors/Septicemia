using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Enemy
{

    // Start is called before the first frame update
    void Start()
    {
        health = 200;
        damage = 0;
    }
}
