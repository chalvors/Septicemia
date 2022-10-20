using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brain_Spawner_Test : MonoBehaviour
{
    [SerializeField]
    private GameObject brainPrefab;

    [SerializeField]
    private float spawnInterval = 1f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBrain(spawnInterval, brainPrefab));
    }

    private IEnumerator spawnBrain(float interval, GameObject brain)
    {
        yield return new WaitForSeconds(interval);
        GameObject newBrain = Instantiate(brain, new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0), Quaternion.identity);
        
        Game_Manager_Test.spawnedCounter++;

        StartCoroutine(spawnBrain(interval, brain));
    }
}
