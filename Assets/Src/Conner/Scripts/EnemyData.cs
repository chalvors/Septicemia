using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Enemy Data", menuName = "ScriptableObjects/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    //Enemy stats
    public int health = 25;
    public int damage = 10;
    public float speed = 1f;
}
