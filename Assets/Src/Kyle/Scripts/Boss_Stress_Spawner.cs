/*
* Boss_Stress_Spawner.cs
* Kyle Hash
* Sinlgeton Pattern for managing audio
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
* Contains functions and a couroutine to spawn mass amounts of Bosses
* Start() - Starts the coroutine to spawn Bosses
* spawnBoss() - Takes in the spawn rate and the boss prefab and spawn bosses recursively
*/
public class Boss__Stress_Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 0.5f;

    public GameObject prefab;
    public Transform player;



    // ------------- Starts the coroutine --------------------
    void Start()
    {
        StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));

    }

    // ------------ Takes in the spawn rate and the boss prefab and spawn bosses recursively ---------------
    private IEnumerator spawnBoss(float interval, GameObject boss)
    {
        yield return new WaitForSeconds(interval);

        GameObject newBoss = Instantiate(prefab, new Vector2(Random.Range(-20, -14), Random.Range(-4, -8)), Quaternion.identity);

        StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));
        
    }
 
}
