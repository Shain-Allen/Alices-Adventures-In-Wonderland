using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaControl : MonoBehaviour
{
    public Items teaTime;

    Rigidbody2D rb;
    Transform target;
    Vector2 pathToTarget;
    float despawnTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        pathToTarget = (target.position - transform.position).normalized;

        despawnTime = teaTime.despawnTime;
    }

    private void FixedUpdate()
    {
        rb.AddForce(pathToTarget * teaTime.speed, ForceMode2D.Force);
    }

    private void Update()
    {
        despawnTime -= Time.deltaTime;

        if(despawnTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<AliceStatControll>().HealthBoost(teaTime.healthChange, teaTime.sound[0]);
            Destroy(gameObject);
        }
    }
}
