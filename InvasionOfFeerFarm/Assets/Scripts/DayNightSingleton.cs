using UnityEngine;
using UnityEngine.Events;
public enum Crops
{
    pumpkin,
    potato,
    carrot,
    tomato,
    bean
}
public class DayNightSingleton : MonoBehaviour
{
    

    public static DayNightSingleton instance;
    public bool isDay = true; //true for day, false for night
    public int enemiesRemaining;
    public Crops currentCrop;
    public UnityEvent newDay = new UnityEvent();
    public UnityEvent newNight = new UnityEvent();
    public int cycles;
    private DayNightSingleton()
    {
        //initialize boolean and variables here
        enemiesRemaining = 0;
        cycles = 0;

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
