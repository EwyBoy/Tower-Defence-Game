using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public int wave;
    public float waveStartDelay = 1.0f;
    public float enemySpawnRepeatRate = 10.0f;
    public GameObject enemyObject;
    public int enemyCount = 0;
    
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), waveStartDelay, enemySpawnRepeatRate);
    }

    void SpawnEnemy()
    {
        if (enemyCount < int.MaxValue)
        {
            enemyObject.name = "Enemy:" + enemyCount;
            Instantiate(enemyObject, transform.position, enemyObject.transform.rotation);
            enemyCount++;
        }
    }

}
