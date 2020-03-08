using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeControll : MonoBehaviour
{

    public Items cake;
    private Rigidbody2D rb;

    Transform target;
    Vector2 pathToTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        pathToTarget = (target.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        rb.AddForce(pathToTarget * cake.speed, ForceMode2D.Force);
    }
}
