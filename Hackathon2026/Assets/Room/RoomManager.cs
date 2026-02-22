using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject spawnerPrefab;
    public GameObject[] enemyPrefabs;
    public GameObject[] propPrefabs;
    public GameObject chestPrefab;

    [Header("Room Settings")]
    public int minEnemyCount, maxEnemyCount;
    public int roomWidth, roomHeight;
    

    void createSpawners()
    {
        int enemyCount = Random.Range(minEnemyCount, maxEnemyCount + 1);
        
        int baseCount = enemyCount / enemyPrefabs.Length;
        //Debug.Log(baseCount);

        foreach (var enemyType in enemyPrefabs)
        {
            GameObject spawnerObj = Instantiate(spawnerPrefab, Vector3.zero, Quaternion.identity);
            EnemySpawner spawner = spawnerObj.GetComponent<EnemySpawner>();

            spawner.enemyPrefab = enemyType;
            spawner.enemyCount = baseCount;
            spawner.spawnEnemy();
        }
    }

    void spawnProps()
    {
        foreach (var propType in propPrefabs)
        {
            Vector3 position = new Vector3(
                Random.Range(1, roomWidth - 1) - roomHeight / 2,
                Random.Range(1, roomHeight - 1) - roomHeight / 2);

            Instantiate(propType, position, Quaternion.identity);
        }

    }

    void spawnChest()
    {
        Instantiate(chestPrefab, Vector3.zero, Quaternion.identity);
    }

    public void startRoom()
    {
        createSpawners();
        spawnProps();
    }

    // Start is called before the first frame update
    void Start()
    {
        // need to make everything blank
         //startRoom();
        // spawnChest();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: seatch for tag and if no enemies, spawn chest.
    }
}
