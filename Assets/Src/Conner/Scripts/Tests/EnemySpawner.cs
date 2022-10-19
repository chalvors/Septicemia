using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject passiveEnemyPrefab;

    [SerializeField]
    private float spawnInterval = 1f;

    private static int totalVal;

    //private Text total;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, passiveEnemyPrefab));

        //total = GetComponent<Text>();
        //totalVal = 0;
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0), Quaternion.identity);
        //totalVal += 1;
        //total.text = "Total Enemy Count: " + totalVal;
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
