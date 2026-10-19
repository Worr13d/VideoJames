using UnityEngine;

public class PlayerDayNightCycle : MonoBehaviour
{

    private DayNightSingleton instance;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite[] costumes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;
    }
    // pumpkin potato tomato bean

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


}
