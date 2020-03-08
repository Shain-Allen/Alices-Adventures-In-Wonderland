using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliceStatControll : MonoBehaviour
{
    //health stuff
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //size stuff
    public float startingSizeScale = 1f;
    public float scaleChangeDuration = 5.0f;
    float currentSizeScale;
    public float nextSizeScale;

    //other stuff
    float starttime;

    private void Start()
    {
        currentSizeScale = startingSizeScale;
        nextSizeScale = startingSizeScale;

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

    private void Update()
    {
        heartControl();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void ChangeSize(float NewSize)
    {
        nextSizeScale = currentSizeScale;
        nextSizeScale += NewSize;
    }

    void heartControl()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
