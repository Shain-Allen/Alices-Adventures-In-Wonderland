using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliceStatControll : MonoBehaviour
{
    public float startingHealth = 3f;
    public float startingSizeScale = 1f;
    public float scaleChangeDuration = 5.0f;
    public float currenthealth;
    public float maxHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    float currentSizeScale;
    public float nextSizeScale;
    float starttime;

    private void Start()
    {
        currenthealth = startingHealth;
        currentSizeScale = startingSizeScale;
        nextSizeScale = startingSizeScale;
        maxHealth = startingHealth;

        starttime = Time.time;
    }

    private void FixedUpdate()
    {
        if (currentSizeScale != nextSizeScale)
        {
            float t = (Time.time - starttime) / scaleChangeDuration;
            transform.localScale = new Vector2(Mathf.SmoothStep(currentSizeScale, nextSizeScale, t), Mathf.SmoothStep(currentSizeScale, nextSizeScale, t));
        }
    }

    public void TakeDamage(float damage)
    {
        currenthealth -= damage;
    }

    public void ChangeSize(float NewSize)
    {
        nextSizeScale = currentSizeScale;
        nextSizeScale += NewSize;
    }
}
