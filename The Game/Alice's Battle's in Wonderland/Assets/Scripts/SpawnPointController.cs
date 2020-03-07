using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{

    public GameObject[] Enemys;

    //Conection to the EnemySpawnManager
    EnemySpawnManager esm;

    private void Start()
    {
        esm = GetComponentInParent<EnemySpawnManager>();
    }

    public void SpawnEnemy()
    {
        int r = Random.Range(0, Enemys.Length);

        Instantiate(Enemys[r], transform.position, Quaternion.identity);
    }
}
