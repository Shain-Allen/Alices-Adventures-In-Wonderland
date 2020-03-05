using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMovement : MonoBehaviour
{
    public float speed = 5f;
    Vector3 pathToTarget;
    Vector2 growPoint;
    Transform target;
    Rigidbody2D rb;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        pathToTarget = target.position - transform.position;
        growPoint = transform.position + (pathToTarget / 2f);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.position != growPoint)
        {
            rb.position = Vector3.MoveTowards(rb.position, growPoint, speed*Time.deltaTime);
        }

        if (rb.position == growPoint)
        {
            anim.SetBool("Inlarge", true);
        }
    }
}
