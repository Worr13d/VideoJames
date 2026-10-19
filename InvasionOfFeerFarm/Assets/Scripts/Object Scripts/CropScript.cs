using UnityEngine;

public class CropScript : MonoBehaviour
{
    private enum CropState
    {
        planted,
        sprouted,
        growing,
        growinger,
        grown
    }
    
    //values of the crop
    //NOTE: Unserialize things that are serialized for testing
    [SerializeField] private int value;
    [SerializeField]private CropState state;
    [SerializeField]public Crops type;
    SpriteRenderer cropRenderer;


    //sprite vars
    private string cropSpritePath = "Assets/Sprites/objects&items/plants free.png";
    private Sprite[] spriteSheet;
    private Sprite[] sprites;

    //singleton
    DayNightSingleton instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;

        //gets the sprite renderer
        cropRenderer = gameObject.GetComponent<SpriteRenderer>();

        //loads all the sprites
        spriteSheet = (Sprite[])Resources.LoadAll(cropSpritePath, typeof(Sprite));

        sprites = new Sprite[5];

        //locks in which sprites are relevant
        switch (type)
        {
            case Crops.pumpkin:
                for(int i = 0; i > 5; i++)
                {
                    sprites[i] = spriteSheet[i];
                }
                break;
            case Crops.potato:
                for (int i = 5; i > 10; i++)
                {
                    sprites[i - 5] = spriteSheet[i];
                }
                break;
            case Crops.carrot:
                for (int i = 10; i > 15; i++)
                {
                    sprites[i - 10] = spriteSheet[i];
                }
                break;
            case Crops.tomato:
                for (int i = 15; i > 20; i++)
                {
                    sprites[i - 15] = spriteSheet[i];
                }
                break;
            case Crops.bean:
                for (int i = 20; i > 25; i++)
                {
                    sprites[i - 20] = spriteSheet[i];
                }
                break;
            default:
                break;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        //switches the sprites
        switch (state)
        {
            case CropState.planted:
                cropRenderer.sprite = spriteSheet[0];
                break;
            case CropState.sprouted:
                cropRenderer.sprite = sprites[1];
                break;
            case CropState.growing:
                cropRenderer.sprite = sprites[2];
                break;
            case CropState.growinger:
                cropRenderer.sprite = sprites[3];
                break;
            case CropState.grown:
                cropRenderer.sprite = sprites[4];
                break;
            default:
                break;
        }
    }
}
