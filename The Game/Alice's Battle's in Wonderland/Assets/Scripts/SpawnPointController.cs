using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{

    public GameObject[] Enemys;

    public void SpawnEnemy()
    {
        int r = Random.Range(0, Enemys.Length);

        Instantiate(Enemys[0], transform.position, Quaternion.identity);
    }
}
