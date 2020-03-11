using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "AAIW/New Item")]
public class Items : ScriptableObject
{
    public float speed = 2;
    public float despawnTime = 5;
    public int maxHealthChange;
    public int healthChange;
    public int sizeChange;
    public AudioClip[] sound;
}
