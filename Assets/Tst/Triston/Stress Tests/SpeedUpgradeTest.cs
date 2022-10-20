using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradeTest : MonoBehaviour
{
    PlayerMovementTest player;
    [SerializeField]
    private GameObject Sensorleft;
    [SerializeField]
    private GameObject Sensorright;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<PlayerMovementTest>();
        StartCoroutine(upgrade());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator upgrade()
    {
        while (!Sensorleft.GetComponent<PlayerSensor>().EnteredTrigger && !Sensorright.GetComponent<PlayerSensor>().EnteredTrigger)
        {
            player.SpeedUpgrade();
            yield return new WaitForSeconds(1f);
        }
    }
}
