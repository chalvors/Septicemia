/*
* EnemySpawner.cs
* Conner Mullins
* A spawner for my stress test
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/*
 * This is the test enemy spawner script, which creates the enemies constantly until they collide with a sensor
 * 
 * member variables:
 * testEnemyPrefab - Holds the prefab for the test enemy
 * sensor - A 2d object that is a trigger
 * spawnInterval - How many seconds will pass until the next enemy spawns
 * totalCount - Text that displays how many enemies have been spawned
 * total - The integer that is incremented when an enemy spawns
 */
public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject testEnemyPrefab;

    [SerializeField]
    private GameObject sensor;

    [SerializeField]
    private float spawnInterval = 1f;

    public Text totalCount;
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        //Total enemies is 0 at the start
        total = 0;
        totalCount.text = "Total Enemy Count: " + total;

        //Begin spawning enemies
        StartCoroutine(spawnEnemy(spawnInterval, testEnemyPrefab));
    }

    //Instantiates an enemy within the scene
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        //Wait for the spawn delay
        yield return new WaitForSeconds(interval);

        //If the enemy has not yet run into a sensor...
        if (!sensor.GetComponent<SensorScript>().enteredTrigger) {
            //Create an enemy within the given range
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);

            //Increment total enemies spawned
            total += 1;

            //Update displayed text to show number of enemies spawned
            totalCount.text = "Total Enemy Count: " + total;

            //Sanity check to make sure the enemy has not entered the trigger
            Debug.Log(sensor.GetComponent<SensorScript>().enteredTrigger);

            //Run this coroutine again
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
