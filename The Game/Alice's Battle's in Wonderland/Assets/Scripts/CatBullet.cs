using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    Transform Target;
    Vector2 pathToTarget;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.Find("Alice temp").GetComponent<Transform>();

        pathToTarget = (transform.position - Target.position).normalized;
    }

    private void Update()
    {
        rb.AddForce(pathToTarget * speed, ForceMode2D.Impulse);

        Debug.DrawLine(transform.position, pathToTarget);
    }
}
