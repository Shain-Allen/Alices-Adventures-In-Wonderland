using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBullet : MonoBehaviour
{
    public float speed = 2;
    public float lifetime = 5;
    private Rigidbody2D rb;

    Transform Target;
    Vector2 pathToTarget;
    float lifeTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Target = GameObject.FindGameObjectWithTag("Player").transform;

        pathToTarget = (Target.position - transform.position).normalized;

        lifeTimeLeft = lifetime;
    }

    void FixedUpdate()
    {
        rb.AddForce(pathToTarget * speed, ForceMode2D.Force);
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
}
