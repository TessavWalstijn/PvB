using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEnemySpawning : MonoBehaviour
{
    public float enemySpawnTimer;
    public float enemySpawnCounter;
    public GameObject enemy;
    
    void Start()
    {
        enemySpawnTimer = 5;
        InvokeRepeating("Spawn", 2.5f, enemySpawnTimer);
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, transform.rotation);
        enemySpawnCounter++;
    }

    void Update()
    {
        if(enemySpawnCounter >= 10)
        {
            enemySpawnTimer = 4f;
        }
        if(enemySpawnCounter >= 20)
        {
            enemySpawnTimer = 3f;
        }
    }
}
