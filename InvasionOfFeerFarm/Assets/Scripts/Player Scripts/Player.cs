using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Entity
{
    private DayNightSingleton instance;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] costumes;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float attackCooldown = 1f;
    private float cooldownTimer = 0f;
    private Vector2 direction;
    private Vector2 velocity;
    private Vector2 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Sprite switching based on day/night cycle
        if (instance.isDay)
        {
            ChangeSprite(0);
        }
        else
        {
            ChangeSprite(1);
        }


        //handles rotation
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 direction2 = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);
        float angle = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (rb.rotation > 90 || rb.rotation < -90)
        {
            rb.gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            rb.gameObject.GetComponent<SpriteRenderer>().flipY = false;

        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        //basic movement
        velocity = direction.normalized * speed;
        position = rb.position + velocity * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }

    /// <summary>
    /// moves
    /// </summary>
    /// <param name="ctx"></param>
    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
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
        if (cooldownTimer <= 0)
        {
            if (!instance.isDay)
            {
                Shoot();
            }
            else
            {
                Harvest();
            }
            cooldownTimer = attackCooldown;
        }
    }

    public void OnInteract(InputAction.CallbackContext ctx)
    {
        print("Interacting");
        instance.water.Invoke();

    }

    /// <summary>
    /// Activates when clicked during the nighttime - Shoots gun
    /// </summary>
    protected override void Shoot()
    {
        GameObject newInstance = Instantiate(bullet, transform.position + transform.right, transform.rotation);
    }

    /// <summary>
    /// Activates when clicked during the daytime - Greg do your shit twin
    /// </summary>
    protected void Harvest()
    {
        instance.plantOrHarvest.Invoke();
        print("harvesting");
        
    }
}
