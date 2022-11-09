using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public static SpawnScript Instance;

    [SerializeField]
    private GameObject[] enemies;

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
        float spawnPosX = Random.Range(-3, 3);
        float spawnPosY = Random.Range(-6, -1);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

        GameObject newEnemy = Instantiate(enemies[1], spawnPos, Quaternion.identity) as GameObject;
    }
}
