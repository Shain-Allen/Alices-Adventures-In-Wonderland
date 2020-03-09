using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "AAIW/New Enemy")]
public class Enemys : ScriptableObject
{
    public float speed = 2;
    public float despawnTime = 5;
    public int damage = 1;
}
