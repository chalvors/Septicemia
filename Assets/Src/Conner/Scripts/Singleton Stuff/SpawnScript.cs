/*
* SpawnScript.cs
* Conner Mullins
* A spawner that instantiates enemies and bosses in waves
*/
using Pathfinding;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;


public class SpawnScript : MonoBehaviour
{
    public static SpawnScript Instance;

    private Transform player;

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

    [SerializeField]
    private AudioClip gameMusic;

    public int enemiesRemaining = 0;

    public Collider2D[] colliders;
    public float radius;

    // Start is called before the first frame update
    void Awake()
    {
        // If there is no instance of this singleton, create one
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(spawnEnemies());
        }

        // There is already an instance, so delete this one
        else
        {
            Destroy(gameObject);
        }
    }

    //This is how each of the enemy waves will be spawned, at least for now
    IEnumerator spawnEnemies()
    {
        //************************** First round ************************** 
        GameManager.round = 1;
        enemiesRemaining = 0;

        yield return new WaitForSeconds(10);

        for (int i = 0; i < 8; i++) {
            meleeEnemy();
            yield return new WaitForSeconds(8);
            //Debug.Log("Enemies Remaining: " + enemiesRemaining);
        }
        
        while(enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }

        //Wait for 30 seconds
        yield return new WaitForSeconds(30);

        //************************** Second Round ************************** 
        GameManager.round = 2;
        enemiesRemaining = 0;

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(8);
            meleeEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(10);

        //************************** Third Round ************************** 
        GameManager.round = 3;
        enemiesRemaining = 0;

        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(8);
            meleeEnemy();
        }

        //Wait for 10 seconds
        yield return new WaitForSeconds(30);

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(8);
            pistolEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //Wait for 30 seconds
        yield return new WaitForSeconds(10);

        //************************** Fourth Round ************************** 
        GameManager.round = 4;
        enemiesRemaining = 0;

        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(5);
            meleeEnemy();
            yield return new WaitForSeconds(5);
            pistolEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //Wait for 30 seconds
        yield return new WaitForSeconds(10);

        //************************** Fifth Round ************************** 
        GameManager.round = 5;
        enemiesRemaining = 0;

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(5);
            meleeEnemy();
            yield return new WaitForSeconds(5);
            pistolEnemy();
        }
        Boss();

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //Wait for 30 seconds
        yield return new WaitForSeconds(30);

        //************************** Sixth Round ************************** 
        GameManager.round = 6;
        enemiesRemaining = 0;

        for (int i = 0; i < 13; i++)
        {
            yield return new WaitForSeconds(5);
            meleeEnemy();
            yield return new WaitForSeconds(5);
            pistolEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //Wait for 30 seconds
        yield return new WaitForSeconds(10);

        //************************** Seventh Round ************************** 
        GameManager.round = 7;
        enemiesRemaining = 0;

        for (int i = 0; i < 15; i++)
        {
            yield return new WaitForSeconds(5);
            meleeEnemy();
            yield return new WaitForSeconds(5);
            pistolEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //Wait for 30 seconds
        yield return new WaitForSeconds(10);

        //************************** Eighth Round ************************** 
        GameManager.round = 8;
        enemiesRemaining = 0;

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(4);
            meleeEnemy();
            yield return new WaitForSeconds(4);
            pistolEnemy();
            yield return new WaitForSeconds(4);
            rifleEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //Wait for 30 seconds
        yield return new WaitForSeconds(30);

        //************************** Ninth Round ************************** 
        GameManager.round = 9;
        enemiesRemaining = 0;

        for (int i = 0; i < 12; i++)
        {
            yield return new WaitForSeconds(4);
            meleeEnemy();
            yield return new WaitForSeconds(4);
            pistolEnemy();
            yield return new WaitForSeconds(4);
            rifleEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //Wait for 30 seconds
        yield return new WaitForSeconds(10);

        //************************** Final Round ************************** 
        GameManager.round = 10;
        enemiesRemaining = 0;

        Boss();
        for (int i = 0; i < 13; i++)
        {
            yield return new WaitForSeconds(4);
            meleeEnemy();
            yield return new WaitForSeconds(4);
            pistolEnemy();
            yield return new WaitForSeconds(4);
            rifleEnemy();
        }
        Boss();

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("You have beat the game!! Congratulations!");
    }

    public void meleeEnemy()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(-25, 21);
            float spawnPosY = Random.Range(-18, 20);

            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break;
            }
        }
        GameObject newEnemy = Instantiate(enemies[0], spawnPos, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = enemyContainer.transform;
        enemiesRemaining++;

        player = GameObject.FindWithTag("PLAYER").transform;
        AIDestinationSetter aiDestSetter = newEnemy.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player;
    }

    public void pistolEnemy()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(-25, 21);
            float spawnPosY = Random.Range(-18, 20);

            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break;
            }
        }

        GameObject newEnemy = Instantiate(enemies[1], spawnPos, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = enemyContainer.transform;
        enemiesRemaining++;

        player = GameObject.FindWithTag("PLAYER").transform;
        AIDestinationSetter aiDestSetter = newEnemy.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player;
    }

    public void rifleEnemy()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(-25, 21);
            float spawnPosY = Random.Range(-18, 20);

            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break;
            }
        }

        GameObject newEnemy = Instantiate(enemies[2], spawnPos, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = enemyContainer.transform;
        enemiesRemaining++;

        player = GameObject.FindWithTag("PLAYER").transform;
        AIDestinationSetter aiDestSetter = newEnemy.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player;
    }

    public void Boss()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        while (!canSpawnHere)
        {
            float spawnPosX = Random.Range(-25, 21);
            float spawnPosY = Random.Range(-18, 20);

            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = PreventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break;
            }
        }

        GameObject newBoss = Instantiate(boss, spawnPos, Quaternion.identity) as GameObject;
        newBoss.transform.parent = bossContainer.transform;
        enemiesRemaining++;

        player = GameObject.FindWithTag("PLAYER").transform;
        AIDestinationSetter aiDestSetter = newBoss.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player;
    }

    //Check if there is overlap between two objects for enemy instantiation
    bool PreventSpawnOverlap(Vector3 spawnPos)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++) {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            //If there is an obstacle at this location, then the enemy cannot spawn here
            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            }
        }

        //If this location is empty, then the enemy can spawn here
        return true;
    }
}