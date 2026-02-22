using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int enemyCount;

    public int roomWidth = 16;
    public int roomHeight = 6;

    public void spawnEnemy()
    {

        for (int i = 0; i < enemyCount; i++) 
        {
            Vector3 spawnPos = new Vector3(
                Random.Range(1, roomWidth - 1) - roomWidth / 2,
                Random.Range(1, roomHeight - 1) - roomHeight / 2
            );

            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

}
