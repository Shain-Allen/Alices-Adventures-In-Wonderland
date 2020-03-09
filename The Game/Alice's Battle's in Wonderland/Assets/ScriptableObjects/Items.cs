using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class Items : ScriptableObject
{
    public float speed;
    public float despawnTime;
    public int maxHealthChange;
    public int healthChange;
    public int sizeChange;
}
