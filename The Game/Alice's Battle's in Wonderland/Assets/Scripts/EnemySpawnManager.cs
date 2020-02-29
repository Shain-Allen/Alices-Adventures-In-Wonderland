using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemySpawners;

    //in seconds
    public float spawnIntervel = 5.0f;
    float timeTillNextSpawn;

    private void Start()
    {
        timeTillNextSpawn = spawnIntervel;
    }

    private void Update()
    {
        timeTillNextSpawn -= Time.deltaTime;

        if (timeTillNextSpawn <= 0)
        {
            int r = Random.Range(0, enemySpawners.Length);

            enemySpawners[0].GetComponent<SpawnPointController>().SpawnEnemy();

            timeTillNextSpawn = spawnIntervel;
        }

        //Debug.Log(timeTillNextSpawn);
    }
}
