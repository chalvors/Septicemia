using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerBoss : Bosses
{

    BaseBoss baseBoss;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        attackDamage = 10;
    }

    public override int GetDamage()
    {
        return baseBoss.GetDamage() + 100;
    }

    // Start is called before the first frame update
    public override int GetHealth()
    {
        return baseBoss.GetHealth() + 100;
    }

    /*
    public override int IncreaseHealth()
    {
        return baseBoss.GetHealth() + 100;
    }
    */
}

