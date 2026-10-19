using UnityEngine;

public class CropScript : MonoBehaviour
{
    private enum cropState
    {
        planted,
        sprouted,
        growing,
        growinger,
        grown
    }
    
    //values of the crop
    [SerializeField] private int value;
    private cropState state;
    [SerializeField]public Crops type;


    //sprite vars
    private string cropSpritePath = "Assets/Sprites/objects&items/plants free.png";
    private Sprite[] sprites;

    //singleton
    DayNightSingleton instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;
        sprites = Resources.LoadAll<Sprite>(cropSpritePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
