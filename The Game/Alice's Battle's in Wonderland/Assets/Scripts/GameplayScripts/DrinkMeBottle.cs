using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMeBottle : MonoBehaviour
{
    public Items bottle;

    Rigidbody2D rb;
    Transform target;
    Vector2 pathToTarget;
    float despawnTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        pathToTarget = (target.position - transform.position).normalized;

        despawnTime = bottle.despawnTime;
    }

    private void FixedUpdate()
    {
        rb.AddForce(pathToTarget * bottle.speed, ForceMode2D.Force);
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
            AliceStatControll player = other.GetComponent<AliceStatControll>();

            player.ChangeSize(bottle.sizeChange);
            player.HealthBoost(bottle.healthChange);
            player.IncreaseNumOfHearts(bottle.maxHealthChange);
            Destroy(gameObject);
        }
    }
}
