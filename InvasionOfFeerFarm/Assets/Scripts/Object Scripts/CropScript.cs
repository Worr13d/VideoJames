using UnityEngine;

public class CropScript : MonoBehaviour
{
    public enum CropState
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
    private string cropSpritePath = "Sprites/objects&items/plantsFree";
    private Sprite[] spriteSheet;
    private Sprite[] sprites;

    //singleton
    DayNightSingleton instance;

    //accessor for value
    /// <summary>
    /// The value of the crop
    /// </summary>
    public int Value
    {
        get { return value; }
    }

    public CropState State { get { return state; } }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;

        //gets the sprite renderer
        cropRenderer = gameObject.GetComponent<SpriteRenderer>();

        //loads all the sprites
        spriteSheet = Resources.LoadAll<Sprite>(cropSpritePath);

        sprites = new Sprite[5];

        type = instance.currentCrop;
    }

    // Update is called once per frame
    void Update()
    {
        //locks in which sprites are relevant
        //handles the value based on crop type
        switch (type)
        {
            case Crops.pumpkin:
                for (int i = 0; i < 5; i++)
                {
                    sprites[i] = spriteSheet[i];
                }
                value = 20;
                break;
            case Crops.potato:
                for (int i = 5; i < 10; i++)
                {
                    sprites[i - 5] = spriteSheet[i];
                }
                value = 6;
                break;
            case Crops.carrot:
                for (int i = 10; i < 15; i++)
                {
                    sprites[i - 10] = spriteSheet[i];
                }
                value = 8;
                break;
            case Crops.tomato:
                for (int i = 15; i < 20; i++)
                {
                    sprites[i - 15] = spriteSheet[i];
                }
                value = 12;
                break;
            case Crops.bean:
                for (int i = 20; i < 25; i++)
                {
                    sprites[i - 20] = spriteSheet[i];
                }
                value = 10;
                break;
            default:
                break;
        }

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
