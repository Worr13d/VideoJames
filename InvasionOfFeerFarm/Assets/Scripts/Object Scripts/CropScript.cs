using UnityEngine;

public class CropScript : MonoBehaviour
{
    private enum cropState
    {
        dirt,
        planted,
        growing,
    }
    //value of the crop
    [SerializeField] private int value;
    [SerializeField] private int poo;
    DayNightSingleton instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
