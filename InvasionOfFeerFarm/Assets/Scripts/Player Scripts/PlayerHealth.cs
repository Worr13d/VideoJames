using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] costumes;
    private DayNightSingleton instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.isDay)
        {
            spriteRenderer.sprite = costumes[7];

        }
        else
        { 
        if (instance.health == 6)
        {
            spriteRenderer.sprite = costumes[6];
        }
        else if (instance.health == 5)
        {
            spriteRenderer.sprite = costumes[5];
        }
        else if (instance.health == 4)
        {
            spriteRenderer.sprite = costumes[4];
        }
        else if (instance.health == 3)
        {
            spriteRenderer.sprite = costumes[3];
        }
        else if (instance.health == 2)
        {
            spriteRenderer.sprite = costumes[2];
        }
        else if (instance.health == 1)
        {
            spriteRenderer.sprite = costumes[1];
        }
        else if (instance.health == 0)
        {
            spriteRenderer.sprite = costumes[0];
        }
        else
        {
            spriteRenderer.sprite = costumes[7];
        }
        }
    

    }


    }
