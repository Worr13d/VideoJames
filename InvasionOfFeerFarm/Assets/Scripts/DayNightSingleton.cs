using UnityEngine;

public class DayNightSingleton : MonoBehaviour
{
    public static DayNightSingleton instance;
    public bool isDay = true; //true for day, false for night
    private DayNightSingleton()
    {
        //initialize boolean and variables here

    }

    //creates an instance of the object, and keeps whatever it's attatched to loaded across scenes
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
