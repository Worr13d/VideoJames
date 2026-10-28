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
    private float timer;

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
        timer += Time.deltaTime;
        // rotation and shooting
        if (Vector3.Distance(transform.position,player.transform.position) < viewRange)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            if (type == EnemyTypes.gunner)
            {
                if (timer > 3f)
                {
                    Shoot();
                    timer = 0;
                }
            }
            else if (type == EnemyTypes.dualGunner)
            {
                if (timer > 1.5f)
                {
                    Shoot();
                    timer = 0;
                }
            }
            else if (type == EnemyTypes.cannoneer)
            {
                if (timer > 6)
                {
                    Shoot();
                    timer = 0;
                }
            }
        }

        // movement
        if (Vector3.Distance(transform.position, player.transform.position) < viewRange)
        {
            // flee if gun seek if gunless
        }
        else
        {
            // pick random direction and wonder
        }
    }
    
    /// <summary>
    /// switch sprite to costume index
    /// </summary>
    /// <param name="index"></param>
     void ChangeSprite(int index)
     {
        spriteRenderer.sprite = sprites[index];

     }

    /// <summary>
    /// shoot
    /// </summary>
    protected override void Shoot()
    {
        print("ballsack micah laney");
    }

    /// <summary>
    /// collision handling with bullets
    /// </summary>
    /// <param name="collision"></param>
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
