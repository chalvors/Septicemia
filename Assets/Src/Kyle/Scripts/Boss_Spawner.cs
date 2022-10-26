using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 0.5f;
    
    public GameObject prefab;
    public Transform player;
    //public GameObject.find("Player");


    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));
        
        

        
    }


    private IEnumerator spawnBoss(float interval, GameObject boss)
    {
        yield return new WaitForSeconds(interval);
        //GameObject Iboss boss = new Boss();
        GameObject newBoss = Instantiate(prefab, new Vector2(Random.Range(-20,-14),Random.Range(-4, -8)), Quaternion.identity);

         StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));
        //player = gameObject.transform;
        //newBoss.GetComponent("Player");
        //newBoss = GameObject.AddComponent<Player>();
       
        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
