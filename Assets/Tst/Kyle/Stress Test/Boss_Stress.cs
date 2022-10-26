using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Stress : MonoBehaviour
{
    [SerializeField]
    private GameObject Sensor;

    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 0.5f;

    public GameObject prefab;
    public Transform player;
    
    public Text totalCount;
    private int total;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));

        total = 0;
        totalCount.text = "total Enemy Count: " + total;


    }


    private IEnumerator spawnBoss(float interval, GameObject boss)
    {
        yield return new WaitForSeconds(interval);
        if (!Sensor.GetComponent<Sensor>().EnteredTrigger)
        {
            GameObject newBoss = Instantiate(prefab, new Vector2(Random.Range(-9, 9), Random.Range(-4, 4)), Quaternion.identity);
            total = total + 1;
            totalCount.text = "Total Enemy Count: " + total;
            Debug.Log(Sensor.GetComponent<Sensor>().EnteredTrigger);
            StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));
        }
 
        //StartCoroutine(spawnBoss(swarmerInterval, swarmerPrefab));
       
        //player = gameObject.transform;
        //newBoss.GetComponent("Player");
        //newBoss = GameObject.AddComponent<Player>();
    }
    
    
}
