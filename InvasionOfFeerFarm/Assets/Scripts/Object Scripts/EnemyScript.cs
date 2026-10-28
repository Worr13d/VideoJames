using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
    [SerializeField] private Rigidbody2D rb;
    private bool hasSeenPlayer;

    protected Vector3 velocity;
    protected Vector3 acceleration;
    protected Vector3 steeringForce;
    private Vector3 randomTarget;
    private float fleeWeight = .5f;
    private float seekWeight = 1f;

    [SerializeField] private GameObject laser1;
    [SerializeField] private GameObject laser2;
    [SerializeField] private GameObject laser3;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("playerTest");
        instance = DayNightSingleton.instance;
        health = Random.Range(3, 7);
        hasSeenPlayer = false;
        randomTarget = (new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10), 0));
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
                viewRange = 5f + Random.Range(-1, 2);
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

            hasSeenPlayer = true;
            seekWeight = 1f;

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


    }

    private void FixedUpdate()
    {
        acceleration = Vector3.zero;

        steeringForce = CalcSteering();
        acceleration += steeringForce;

        Vector3 nextPosition = transform.position;

        velocity += acceleration * Time.fixedDeltaTime;
        velocity = Vector3.ClampMagnitude(velocity, speed);

        nextPosition += velocity * Time.fixedDeltaTime;

        rb.MovePosition(nextPosition);

    }

    protected  Vector3 CalcSteering()
    {
        Vector3 totalForce = Vector3.zero;

        //totalForce += Seek(target) * seekWeight;
         if (Vector3.Distance(transform.position, player.transform.position) < viewRange-1)
         {
            if (type == EnemyTypes.charger)
            {
                totalForce += Seek() * seekWeight * 2;
            }
            else
            {
                totalForce += Flee() * fleeWeight;
            }

        }
        else
        {
            // wonder
        }

         if (hasSeenPlayer && Vector3.Distance(transform.position, player.transform.position) > viewRange)
         {
            totalForce += Seek() * seekWeight;
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

         }
         if (!hasSeenPlayer)
         {
            seekWeight = 0.02f;
            Vector3 direction = (randomTarget - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            totalForce += Seek(randomTarget) * seekWeight;

        }

        //totalForce += Evade(evadeTarget, lookAheadSeconds) * evadeWeight;
        //totalForce += StayInBounds() * stayInBoundsWeight;

        return totalForce;
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
    /// flees DEFAULT FLEES PLAYER - if you want to flee something else, make an override with a param
    /// </summary>
    /// <returns></returns>
    protected Vector3 Flee()
    {
        Vector3 desiredVelocity = transform.position - player.transform.position;
        desiredVelocity = desiredVelocity.normalized * speed;
        return desiredVelocity - velocity;
    }


    /// <summary>
    /// Seeks DEFAULT SEEKS PLAYER - if you want to seek something else, make an override with a param
    /// </summary>
    /// <returns></returns>
    protected Vector3 Seek()
    {
        Vector3 desiredVelocity = player.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * speed;
        return desiredVelocity - velocity;
    }

    /// <summary>
    /// override for specific targets other than player
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    protected Vector3 Seek(Vector3 target)
    {
        Vector3 desiredVelocity = target - transform.position;
        desiredVelocity = desiredVelocity.normalized * speed;
        return desiredVelocity - velocity;
    }



    /// <summary>
    /// shoot
    /// </summary>
    protected override void Shoot()
    {
        if (type == EnemyTypes.gunner)
        {
            GameObject newInstance = Instantiate(laser1, transform.position + transform.right, transform.rotation);
        }
        else if (type == EnemyTypes.dualGunner)
        {
            GameObject newInstance = Instantiate(laser2, transform.position + transform.right, transform.rotation);
        }
        else if (type == EnemyTypes.cannoneer)
        {
            GameObject newInstance = Instantiate(laser3, transform.position + transform.right, transform.rotation);
        }
        else
        { 
            print("ballsack micah laney");
        }
        
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
                Destroy(collision);
            }
        }
    }
}
