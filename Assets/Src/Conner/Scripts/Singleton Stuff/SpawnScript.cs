/*
* SpawnScript.cs
* Conner Mullins
* A spawner that instantiates enemies and bosses in waves
*/
using Pathfinding;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


/*
 * This is the singleton class that is responsible for spawning in enemies in a wave format
 * 
 * void Awake() - Creates an instance of this singleton and calls the spawnEnemies coroutine
 * IEnumerator spawnEnemies() - Coroutine that holds the structure and timing for all of the waves, and updates which round we are currently on
 * meleeEnemy() - Instantiates and places a melee enemy into the scene
 * pistolEnemy() - Instantiates and places a pistol enemy into the scene
 * rifleEnemy() - Instantiates and places a rifle enemy into the scene
 * boss() - Instantiates and places a boss into the scene
 * preventSpawnOverlap(Vector3 spawnPos) - Checks to see if a random location on the map has an obstacle in the way, such as building or cover. If so, it looks for a different location. This continues until a suitable location is found to spawn the enemies.
 * 
 * member variables:
 * Instance - Used to check if this is the only SpawnScript singleton that exists
 * player - Location of the player used to set the pathfinding for enemies
 * enemies - Array that holds enemy prefabs
 * bossPrefab - Holds the boss prefab
 * enemyContainer - Places enemies under "enemies" empty gameObject in the heirarchy to keep the inspector view organized
 * bossContainer - Places bosses under "Bosses" empty gameObject in the heirarchy to keep the inspector view organized
 * gameMusic - Holds the gameplay music audio clip
 * enemiesRemaining - Keeps track of how many enemies are spawned, which is used to determine whether or not the current round can end
 * enemiesSpawning - Bool used to determine if the next round has started
 * colliders - An array that holds all of the colliders within the radius at the selected random location
 * radius - Used to check for colliders in a circular area
 */
public class SpawnScript : MonoBehaviour
{
    public static SpawnScript Instance;

    private GameObject player;
    private GameObject secretRoom;

    [SerializeField]
    private GameObject[] enemies;

    [SerializeField]
    private GameObject bossPrefab;

    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    private GameObject bossContainer;

    [SerializeField]
    private AudioClip gameMusic;

    public int enemiesRemaining = 0;
    public bool enemiesSpawning = false;
    public Collider2D[] colliders;
    public float radius = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        // If there is no instance of this singleton, create one
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            try
            {
                player = GameObject.FindWithTag("PLAYER");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            
            StartCoroutine(spawnEnemies());
        }

        // There is already an instance, so delete this one
        else
        {
            Destroy(gameObject);
            Debug.Log("Got rid of a singleton");
        }
    }

    //This is how each of the enemy waves will be spawned, at least for now
    IEnumerator spawnEnemies()
    {
        // -------------------------- First round --------------------------
        GameManager.round = 1;
        enemiesRemaining = 8;

        yield return new WaitForSeconds(10);

        Debug.Log(player.GetComponent<Player>().inSecretRoom);

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        for (int i = 0; i < 8; i++) {
            meleeEnemy();
            yield return new WaitForSeconds(8);
            //Debug.Log("Enemies Remaining: " + enemiesRemaining);
        }
        
        while(enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Second Round --------------------------
        GameManager.round = 2;
        enemiesRemaining = 10;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

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

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Third Round -------------------------- 
        GameManager.round = 3;
        enemiesRemaining = 13;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        //Spawning melee enemies
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(7);
            meleeEnemy();
        }

        //Wait for 10 seconds
        yield return new WaitForSeconds(10);

        //Spawning pistol enemies
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(7);
            pistolEnemy();
        }

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Fourth Round -------------------------- 
        GameManager.round = 4;
        enemiesRemaining = 16;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        //Spawning a mix of melee enemies and pistol enemies
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

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Fifth Round -------------------------- 
        GameManager.round = 5;
        enemiesRemaining = 21;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        //Spawning a mix of melee enemies, pistol enemies, and a boss
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(5);
            meleeEnemy();
            yield return new WaitForSeconds(5);
            pistolEnemy();
        }
        boss();

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Sixth Round -------------------------- 
        GameManager.round = 6;
        enemiesRemaining = 26;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        //Spawning a mix of melee enemies and pistol enemies
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

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Seventh Round -------------------------- 
        GameManager.round = 7;
        enemiesRemaining = 30;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        //Spawning a mix of melee enemies and pistol enemies
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

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Eighth Round -------------------------- 
        GameManager.round = 8;
        enemiesRemaining = 30;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

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

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Ninth Round -------------------------- 
        GameManager.round = 9;
        enemiesRemaining = 36;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        //Spawning a mix of melee enemies, pistol enemies, and rifle enemies
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

        enemiesSpawning = false;
        Debug.Log("You have survived round " + GameManager.round + "! Well done!");

        //30 second grace period between rounds
        yield return new WaitForSeconds(30);

        //-------------------------- Final Round -------------------------- 
        GameManager.round = 10;
        enemiesRemaining = 41;

        while (player.GetComponent<Player>().inSecretRoom == true)
        {
            yield return new WaitForSeconds(.01f);
        }

        enemiesSpawning = true;

        //Spawning a boss, a mix of melee enemies, pistol enemies, and rifle enemies, and another boss
        boss();
        for (int i = 0; i < 13; i++)
        {
            yield return new WaitForSeconds(4);
            meleeEnemy();
            yield return new WaitForSeconds(4);
            pistolEnemy();
            yield return new WaitForSeconds(4);
            rifleEnemy();
        }
        boss();

        //Waiting for all of the enemies to be killed
        while (enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(1);
        }

        enemiesSpawning = false;
        //Switch to win screen after all enemies have been defeated
        Debug.Log("You have beat the game!! Congratulations!");
    }

    /*
     * Instantiates a melee enemy into the scene within the borders of the map
     * Checks if the spawn location is not in a building or cover by calling preventSpawnOverlap
     * After a suitable location is found, increment the number of enemies in the current round
     * Sets the target for A* Pathfinding to be the location of the player
     */
    public void meleeEnemy()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        //This will repeat until a suitable location is found
        while (!canSpawnHere)
        {
            //Selects a random location within the borders of the map
            float spawnPosX = Random.Range(-22, 20);
            float spawnPosY = Random.Range(-17, 17);

            //Checks if there are any buildings or cover in the way
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = preventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break; //The enemy can spawn at spawnPos
            }
        }

        //Instantiate new enemy and increment the enemy counter
        GameObject newEnemy = Instantiate(enemies[0], spawnPos, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = enemyContainer.transform;
        //enemiesRemaining++;

        //Set the A* Pathfinding target to be the player, so the enemies will follow them
        AIDestinationSetter aiDestSetter = newEnemy.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player.transform;
    }

    /*
     * Instantiates a pistol enemy into the scene within the borders of the map
     * Checks if the spawn location is not in a building or cover by calling preventSpawnOverlap
     * After a suitable location is found, increment the number of enemies in the current round
     * Sets the target for A* Pathfinding to be the location of the player
     */
    public void pistolEnemy()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        //This will repeat until a suitable location is found
        while (!canSpawnHere)
        {
            //Selects a random location within the borders of the map
            float spawnPosX = Random.Range(-22, 20);
            float spawnPosY = Random.Range(-17, 17);

            //Checks if there are any buildings or cover in the way
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = preventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break; //The enemy can spawn at spawnPos
            }
        }

        //Instantiate new enemy and increment the enemy counter
        GameObject newEnemy = Instantiate(enemies[1], spawnPos, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = enemyContainer.transform;
        //enemiesRemaining++;

        //Set the A* Pathfinding target to be the player, so the enemies will follow them
        AIDestinationSetter aiDestSetter = newEnemy.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player.transform;
    }

    /*
     * Instantiates a rifle enemy into the scene within the borders of the map
     * Checks if the spawn location is not in a building or cover by calling preventSpawnOverlap
     * After a suitable location is found, increment the number of enemies in the current round
     * Sets the target for A* Pathfinding to be the location of the player
     */
    public void rifleEnemy()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        //This will repeat until a suitable location is found
        while (!canSpawnHere)
        {
            //Selects a random location within the borders of the map
            float spawnPosX = Random.Range(-22, 20);
            float spawnPosY = Random.Range(-17, 17);

            //Checks if there are any buildings or cover in the way
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = preventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break; //The enemy can spawn at spawnPos
            }
        }

        //Instantiate new enemy and increment the enemy counter
        GameObject newEnemy = Instantiate(enemies[2], spawnPos, Quaternion.identity) as GameObject;
        newEnemy.transform.parent = enemyContainer.transform;
        //enemiesRemaining++;

        //Set the A* Pathfinding target to be the player, so the enemies will follow them
        AIDestinationSetter aiDestSetter = newEnemy.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player.transform;
    }

    /*
     * Instantiates a boss into the scene within the borders of the map
     * Checks if the spawn location is not in a building or cover by calling preventSpawnOverlap
     * After a suitable location is found, increment the number of enemies in the current round
     * Sets the target for A* Pathfinding to be the location of the player
     */
    public void boss()
    {
        Vector3 spawnPos = new Vector3(0, 0, 0);
        bool canSpawnHere = false;

        //This will repeat until a suitable location is found
        while (!canSpawnHere)
        {
            //Selects a random location within the borders of the map
            float spawnPosX = Random.Range(-22, 20);
            float spawnPosY = Random.Range(-17, 17);

            //Checks if there are any buildings or cover in the way
            spawnPos = new Vector3(spawnPosX, spawnPosY, 0);
            canSpawnHere = preventSpawnOverlap(spawnPos);

            if (canSpawnHere)
            {
                break; //The enemy can spawn at spawnPos
            }
        }

        //Instantiate new enemy and increment the enemy counter
        GameObject newBoss = Instantiate(bossPrefab, spawnPos, Quaternion.identity) as GameObject;
        newBoss.transform.parent = bossContainer.transform;
        //enemiesRemaining++;

        //Set the A* Pathfinding target to be the player, so the enemies will follow them
        AIDestinationSetter aiDestSetter = newBoss.GetComponent<AIDestinationSetter>();
        aiDestSetter.target = player.transform;
    }

    /*
     * Check if there is overlap between the random location that is selected and the surrounding colliders
     * If there are no colliders within the radius, then an empty array is returned to colliders and the statement becomes true
     * Otherwise it will check to see if the extents of the bounds overlap with the selected location
     * If so, then it will return false and a new location will be selected
     * Otherwise it returns true and the location is used to instantiate a new enemy
     */
    bool preventSpawnOverlap(Vector3 spawnPos)
    {
        //Collects all colliders within the radius of the location spawnPos
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        //Cycle through all of the colliders that have been found near spawnPos
        for (int i = 0; i < colliders.Length; i++) {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            //Calculate the furthest that the collider extends on all sides
            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            //If there is an obstacle at this location, then the enemy cannot spawn here
            if (spawnPos.x >= leftExtent && spawnPos.x <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false; //The enemy cannot spawn at spawnPos
                }
            }
        }

        //There are no obstacles and the enemy can spawn here
        return true;
    }
}