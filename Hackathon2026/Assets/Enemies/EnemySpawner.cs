using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int minEnemyCount = 2;
    public int maxEnemyCount = 4;

    public int roomWidth = 16;
    public int roomHeight = 6;

    // Start is called before the first frame update
    void Start()
    {
        int enemyCount = Random.Range(minEnemyCount, maxEnemyCount + 1);

        for (int i = 0; i < enemyCount; i++) 
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(1, roomWidth - 1) - roomHeight / 2,
                Random.Range(1, roomHeight - 1) - roomHeight / 2
            );

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

}
