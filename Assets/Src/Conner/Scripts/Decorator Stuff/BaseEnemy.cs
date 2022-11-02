using Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseEnemy : Enemy
{
    [SerializeField]
    private Transform target;

    bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        health = 50;
        damage = 0;

        //IncreaseHealth();
    }

    private void FixedUpdate()
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

    public override int GetDamage()
    {
        return damage;
    }

    public override int GetHealth()
    {
        return health;
    }
}
