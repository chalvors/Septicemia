using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject testEnemyPrefab;

    [SerializeField]
    private GameObject Sensor;

    [SerializeField]
    private float spawnInterval = 1f;

    public Text totalCount;
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, testEnemyPrefab));

        total = 0;
        totalCount.text = "Total Enemy Count: " + total;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        if (!Sensor.GetComponent<SensorScript>().EnteredTrigger) {
            GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
            total += 1;
            totalCount.text = "Total Enemy Count: " + total;
            Debug.Log(Sensor.GetComponent<SensorScript>().EnteredTrigger);
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
}
