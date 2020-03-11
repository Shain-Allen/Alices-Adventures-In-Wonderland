using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AliceStatControll : MonoBehaviour
{
    //public component references
    public Animator anim;

    //health stuff
    [SerializeField]
    int health = 3;
    [SerializeField]
    int numOfHearts = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //size stuff
    int size = 0;

    //sound stuff
    public AudioSource aSource;

    //other stuff
    float starttime;

    private void Start()
    {
        starttime = Time.time;
    }

    private void Update()
    {
        heartControl();
        anim.SetInteger("Size", size);
    }

    public void IncreaseNumOfHearts(int boost, AudioClip sound)
    {
        if (numOfHearts < hearts.Length)
        {
            numOfHearts += boost;
        }
        aSource.PlayOneShot(sound);
    }

    public void IncreaseNumOfHearts(int boost)
    {
        if (numOfHearts < hearts.Length)
        {
            numOfHearts += boost;
        }
    }

    public void HealthBoost(int boost, AudioClip sound)
    {
        if(health < numOfHearts)
        {
            health += boost;
        }
        aSource.PlayOneShot(sound);
    }

    public void HealthBoost(int boost)
    {
        if (health < numOfHearts)
        {
            health += boost;
        }
    }

    public void TakeDamage(int damage, AudioClip sound)
    {
        health -= damage;
        aSource.PlayOneShot(sound);
    }

    public void ChangeSize(int _size, AudioClip sound)
    {
        size += _size;
        aSource.PlayOneShot(sound);
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
