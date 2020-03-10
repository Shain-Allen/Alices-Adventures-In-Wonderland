using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadHatter : MonoBehaviour
{
    private Rigidbody2D rb;
    public float frequency = 1.0f;
    public float amplitude = 1.0f;
    public Enemys madHatter;

    Transform Target;
    Vector2 pathToTarget;
    float angle;
    float despawnTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Target = GameObject.FindGameObjectWithTag("Player").transform;

        pathToTarget = (Target.position - transform.position).normalized;

        despawnTime = madHatter.despawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        despawnTime -= Time.deltaTime;

        if (despawnTime <= 0)
            Destroy(gameObject);

        angle = Mathf.Atan2(pathToTarget.y, pathToTarget.x);

        angle = Mathf.Rad2Deg * angle;

        //create base sine wave with desired Frequency
        Vector2 sinWave = new Vector2(0.0f, Mathf.Sin(Time.timeSinceLevelLoad * frequency)) * amplitude;

        //Rotate by target angle
        sinWave = Quaternion.Euler(new Vector3(0, 0, angle)) * sinWave;

        //change velocity accordingly
        rb.velocity = (pathToTarget + sinWave) * madHatter.speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<AliceStatControll>().TakeDamage(madHatter.damage, madHatter.sound);
        }
    }
}
