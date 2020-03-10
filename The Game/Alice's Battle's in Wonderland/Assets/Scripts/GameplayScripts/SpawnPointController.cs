﻿using System.Collections;
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

        if(esm.numOfQueens == 1)
        {
            r = Random.Range(0, Enemys.Length);
            if (Enemys[r].tag == "Queen")
            {
                SpawnEnemy();
                return;
            }
        }

        if(Enemys[r].tag == "Queen")
        {
            esm.numOfQueens = 1;
        }

        Instantiate(Enemys[r], transform.position, Quaternion.identity);
    }
}