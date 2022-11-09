using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public static SpawnScript Instance;

    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject boss;

    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    private GameObject bossContainer;

    [SerializeField]
    private GameObject spawnPoint;

    private int maxEnemiesOnScreen;
    private int totalEnemies;

    private int enemiesOnScreen = 0;

    // Start is called before the first frame update
    void Awake()
    {
        // If there is no instance of this singleton, create one
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SpawnEnemies();
        }

        // There is already an instance, so delete this one
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnEnemies()
    {
        totalEnemies = 1;
        for (int i = 0; i < totalEnemies; i++)
        {
            float spawnPosX = Random.Range(-3, 3);
            float spawnPosY = Random.Range(-6, -1);
            Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

            GameObject newEnemy = Instantiate(enemies[1], spawnPos, Quaternion.identity) as GameObject;
            newEnemy.transform.parent = enemyContainer.transform;

            GameObject newBoss = Instantiate(boss, spawnPos, Quaternion.identity) as GameObject;
            newBoss.transform.parent = bossContainer.transform;
            StartCoroutine(shortWait());
        }

    }

    IEnumerator shortWait()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator longWait()
    {
        yield return new WaitForSeconds(30f);
    }
}
