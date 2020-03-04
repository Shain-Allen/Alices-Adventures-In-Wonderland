using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadHatter : MonoBehaviour
{
    private Rigidbody2D rb;
    public float frequency = 1.0f;
    public float amplitude = 1.0f;
    public float speed = 1.0f;

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

        //create base sine wave with desired Frequency
        Vector2 sinWave = new Vector2(0.0f, Mathf.Sin(Time.deltaTime * frequency)) * amplitude;

        //Rotate by target angle
        sinWave = Quaternion.Euler(new Vector3(0, 0, angle)) * sinWave;

        //modify pathToTarget using sin wave as offset
        pathToTarget += sinWave;

        //change velocity accordingly
        rb.velocity = pathToTarget * speed;

    }
}
