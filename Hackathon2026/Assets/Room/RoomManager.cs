using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject spawnerPrefab;
    public GameObject[] enemyPrefabs;
    public GameObject[] propPrefabs;

    [Header("Room Settings")]
    public int minEnemyCount, maxEnemyCount;
    public int roomWidth, roomHeight;

    void createSpawners()
    {
        int enemyCount = Random.Range(minEnemyCount, maxEnemyCount + 1);
        int baseCount = enemyCount / enemyPrefabs.Length;

        foreach (var enemyType in enemyPrefabs)
        {
            GameObject spawnerObj = Instantiate(spawnerPrefab, Vector3.zero, Quaternion.identity);
            EnemySpawner spawner = spawnerObj.GetComponent<EnemySpawner>();

            spawner.enemyPrefab = enemyType;
            spawner.enemyCount = baseCount;
            spawner.spawnEnemy();
        }
    }

    void startRoom()
    {
        createSpawners();
    }

    // Start is called before the first frame update
    void Start()
    {
        startRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
