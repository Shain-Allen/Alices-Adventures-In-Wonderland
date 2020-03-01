using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBullet : MonoBehaviour
{
    public float speed = 2;
    private Rigidbody2D rb;

    Transform Target;
    Vector2 pathToTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Target = GameObject.FindGameObjectWithTag("Player").transform;

        pathToTarget = (Target.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        rb.AddForce(pathToTarget * speed, ForceMode2D.Force);
    }
}
