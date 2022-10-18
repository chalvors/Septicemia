using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;



    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));
    }


    private IEnumerator spawnBoss(float interval, GameObject boss)
    {
        yield return new WaitForSeconds(interval);
        GameObject newBoss = Instantiate(boss, new Vector2(Random.Range(-20,-14),Random.Range(-4, -8)), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
