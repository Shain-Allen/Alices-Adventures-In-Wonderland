using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceStatControll : MonoBehaviour
{
    public float startingHealth = 3f;
    public float startingSizeScale = 1f;
    public float scaleChangeDuration = 5.0f;

    float currenthealth;
    float currentSizeScale;
    public float nextSizeScale;
    float starttime;

    private void Start()
    {
        currenthealth = startingHealth;
        currentSizeScale = startingSizeScale;
        nextSizeScale = startingSizeScale;

        starttime = Time.time;
    }

    private void FixedUpdate()
    {
        if (currentSizeScale < nextSizeScale)
        {
            float t = (Time.time - starttime) / scaleChangeDuration;
            transform.localScale = new Vector2(Mathf.SmoothStep(currentSizeScale, nextSizeScale, t), Mathf.SmoothStep(currentSizeScale, nextSizeScale, t));
        }
    }
}
