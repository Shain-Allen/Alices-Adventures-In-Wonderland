using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{

    public GameObject[] Enemys;

    public void SpawnEnemy()
    {
        int r = Random.Range(0, Enemys.Length - 1);

        Instantiate(Enemys[0], transform.position, Quaternion.identity);
    }
}
