using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenMovement : MonoBehaviour
{
    public float speed = 5f;
    Vector3 pathToTarget;
    Vector2 growPoint;
    Vector3 Center = new Vector3(0, 0, 0);
    Transform target;
    Rigidbody2D rb;
    Animator anim;

    bool Grew = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        pathToTarget = Center - transform.position;
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

        if (Grew != true)
        {
            if (rb.position == growPoint)
            {
                //anim.SetBool("Inlarge", true);
                anim.SetTrigger("inLarge");
                Grew = true;
            }
        }
    }
}
