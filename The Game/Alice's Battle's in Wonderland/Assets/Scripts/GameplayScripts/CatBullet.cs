using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBullet : MonoBehaviour
{
    public Enemys stats;

    Rigidbody2D rb;
    Transform target;
    Vector2 pathToTarget;
    float lifeTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        pathToTarget = (target.position - transform.position).normalized;

        lifeTimeLeft = stats.despawnTime;
    }

    void FixedUpdate()
    {
        rb.AddForce(pathToTarget * stats.speed , ForceMode2D.Force);
    }

    private void Update()
    {
        lifeTimeLeft -= Time.deltaTime;

        if(lifeTimeLeft <= 0)
        {
            Destroy(gameObject);
        }

        //Debug.Log(lifeTimeLeft);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<AliceStatControll>().TakeDamage(stats.damage, stats.sound);
        }
    }
}
