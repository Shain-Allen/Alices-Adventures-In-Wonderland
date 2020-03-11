using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeControll : MonoBehaviour
{
    public Items cake;
    private Rigidbody2D rb;

    Transform target;
    Vector2 pathToTarget;
    float timeleft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        pathToTarget = (target.position - transform.position).normalized;

        timeleft = cake.despawnTime;
    }

    private void Update()
    {
        timeleft -= Time.deltaTime;

        if(timeleft <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(pathToTarget * cake.speed, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AliceStatControll player = GameObject.FindGameObjectWithTag("Player").GetComponent<AliceStatControll>();
        player.IncreaseNumOfHearts(cake.maxHealthChange, cake.sound[1]);
        player.HealthBoost(cake.healthChange);
        player.ChangeSize(cake.sizeChange, cake.sound[0]);
        Destroy(gameObject);
    }
}
