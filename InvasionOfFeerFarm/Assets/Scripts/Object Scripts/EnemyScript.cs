using UnityEngine;

public class EnemyScript : Entity
{
    enum EnemyTypes
    {
        gunner,
        dualGunner,
        charger,
        cannoneer
    }

    private EnemyTypes type;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] sprites;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = Random.Range(3, 6);
        switch (Random.Range(1, 5))
        {
            case 1:
                type = EnemyTypes.gunner; ChangeSprite(1); break;
            case 2:
                type = EnemyTypes.dualGunner; ChangeSprite(2); break;
            case 3: 
                type = EnemyTypes.charger; ChangeSprite(0); break;
            case 4:
                type = EnemyTypes.cannoneer; ChangeSprite(3); break;
            default:
                break;

        }


    }

    // Update is called once per frame
    void Update()
    {
            
    }

     void ChangeSprite(int index)
     {
        spriteRenderer.sprite = sprites[index];

     }
    protected override void Shoot()
    {
        print("ballsack micah laney");
    }
}
