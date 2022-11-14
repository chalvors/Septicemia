/*
* TestEnemy.cs
* Conner Mullins
* A script to make a test enemy that only moves upward
*/
using UnityEngine;


public class TestEnemy : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 1;

    void Update()
    {
        transform.Translate(Vector2.up * maxSpeed * Time.deltaTime);
    }
}
