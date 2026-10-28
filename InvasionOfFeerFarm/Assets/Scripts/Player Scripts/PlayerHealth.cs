using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] costumes;
    [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Health == 6)
        {
            spriteRenderer.sprite = costumes[0];
        }
        else if (player.Health == 5)
        {
            spriteRenderer.sprite = costumes[1];
        }
        else if (player.Health == 4)
        {
            spriteRenderer.sprite = costumes[2];
        }
        else if (player.Health == 3)
        {
            spriteRenderer.sprite = costumes[3];
        }
        else if (player.Health == 2)
        {
            spriteRenderer.sprite = costumes[4];
        }
        else if (player.Health == 1)
        {
            spriteRenderer.sprite = costumes[5];
        }
        else if (player.Health == 0)
        {
            spriteRenderer.sprite = costumes[6];
        }
        else
        {
            spriteRenderer.sprite = costumes[6];
        }



    }
}
