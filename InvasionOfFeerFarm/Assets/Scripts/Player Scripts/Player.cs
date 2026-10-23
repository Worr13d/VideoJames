using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    private DayNightSingleton instance;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] costumes;

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
            ChangeSprite(0);
        }
        else
        {
            ChangeSprite(1);
        }
    }

    /// <summary>
    /// switches sprite to the given index in the costumes array
    /// </summary>
    /// <param name="index"></param>
    void ChangeSprite(int index)
    {
        spriteRenderer.sprite = costumes[index];
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        Console.WriteLine("attack");
        if (!instance.isDay)
        {
            Shoot();
            Console.WriteLine("shot>");
        }
        else
        {
            Harvest();
        }
    }

    /// <summary>
    /// Activates when clicked during the nighttime - Shoots gun
    /// </summary>
    protected override void Shoot()
    {
        Console.WriteLine("shoot!");
    }

    /// <summary>
    /// Activates when clicked during the daytime - Greg do your shit twin
    /// </summary>
    protected void Harvest()
    {
        Console.WriteLine("harvest!");
    }
}
