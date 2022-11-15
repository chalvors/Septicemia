/*
* TestEnemy.cs
* Conner Mullins
* A script to make a test enemy that only moves upward
*/
using UnityEngine;


/*
 * This is the test enemy script, which makes the enemies constantly move upwards
 * 
 * member variables:
 * maxSpeed - The speed at which the enemy moves upwards
 */
public class TestEnemy : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 1f;

    void Update()
    {
        //Move upwards
        transform.Translate(Vector2.up * maxSpeed * Time.deltaTime);
    }
}
