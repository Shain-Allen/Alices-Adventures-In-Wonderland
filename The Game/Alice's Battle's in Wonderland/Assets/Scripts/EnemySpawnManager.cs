using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemySpawners;

    //in seconds
    public float spawnIntervel = 5.0f;
    float timeTillNextSpawn;

    //only let there be one queen on screen at a time
    public int numOfQueens = 0;

    private void Start()
    {
        timeTillNextSpawn = spawnIntervel;
    }

    private void Update()
    {
        timeTillNextSpawn -= Time.deltaTime;

        if (timeTillNextSpawn <= 0f)
        {
            int r = Random.Range(0, enemySpawners.Length);

            enemySpawners[r].GetComponent<SpawnPointController>().SpawnEnemy();

            timeTillNextSpawn = spawnIntervel;
        }

        //Debug.Log(timeTillNextSpawn);
    }
}
