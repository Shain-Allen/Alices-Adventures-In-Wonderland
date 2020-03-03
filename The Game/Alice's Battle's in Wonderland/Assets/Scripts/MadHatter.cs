using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadHatter : MonoBehaviour
{
    private Rigidbody2D rb;
    public float frecency = 1.0f;
    public float amplitude = 1.0f;
    public float speed = 5.0f;

    Transform Target;
    Vector2 pathToTarget;
    float angle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Target = GameObject.FindGameObjectWithTag("Player").transform;

        pathToTarget = (Target.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        angle = Mathf.Atan2(pathToTarget.y, pathToTarget.x);

        float x = rb.transform.position.x;
        float y = rb.transform.position.y;

        x = x + Mathf.Cos(angle + Mathf.Sin(Time.deltaTime * speed) * frecency) * amplitude * Time.deltaTime;
        y = y + Mathf.Sin(angle + Mathf.Sin(Time.deltaTime * speed) * frecency) * amplitude * Time.deltaTime;

        rb.MovePosition(new Vector2(x, y));
    }
}
