using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyScript : Entity
{
    enum EnemyTypes
    {
        gunner,
        dualGunner,
        charger,
        cannoneer
    }

    private DayNightSingleton instance;
    private EnemyTypes type;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;
    private GameObject player;
    private float viewRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("playerTest");
        instance = DayNightSingleton.instance;
        health = Random.Range(3, 7);
        switch (Random.Range(1, 5))
        {
            case 1:
                type = EnemyTypes.gunner;
                ChangeSprite(1);
                viewRange = 7f + Random.Range(-1,2);
                break;
            case 2:
                type = EnemyTypes.dualGunner; 
                ChangeSprite(2);
                viewRange = 4.5f + Random.Range(-1, 2);
                break;
            case 3: 
                type = EnemyTypes.charger; 
                ChangeSprite(0);
                viewRange = 3f + Random.Range(-1, 3);
                break;
            case 4:
                type = EnemyTypes.cannoneer; 
                ChangeSprite(3);
                viewRange = 7.5f + Random.Range(-1, 2);

                break;
            default:
                break;

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,player.transform.position) < viewRange)
        {
            // 1. Get the direction vector from this object to the target
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // 2. Calculate the angle in radians, then convert to degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // 3. Apply the rotation to the Z-axis (adjust - 90f if your sprite points "up" instead of "right")
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


        }
    }

     void ChangeSprite(int index)
     {
        spriteRenderer.sprite = sprites[index];

     }
    protected override void Shoot()
    {
        print("ballsack micah laney");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "bullet(Clone)")
        {
            health--;
            if (health <= 0)
            {
                instance.enemiesRemaining--;
                Destroy(gameObject);
            }
        }
    }
}
