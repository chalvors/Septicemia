using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoss : Bosses
{
    BaseBoss myObject;
    
    [SerializeField]
    private Transform target;

    //bool isMoving = true;


    // Start is called before the first frame update
    void Start()
    {
        //Initialize the Base Boss
        health = 100;
        attackDamage = 10;
        //StrongerBoss.GetHealth();
        //IncreaseHealth();
    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        if (target != null && isMoving == false)
        {
            Quaternion rotation = Quaternion.LookRotation(target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            rotation *= Quaternion.Euler(90, 0, 0);
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
        StartCoroutine(moveCheck());
    }

    IEnumerator moveCheck()
    {
        var p1 = transform.parent.position;
        yield return new WaitForSeconds(.5f);
        var p2 = transform.parent.position;

        isMoving = (p1 != p2);
    }
    */
    public override int GetDamage()
    {
        return attackDamage;
    }

    public virtual int GetHealth()
    {
        return health;
    }
}
