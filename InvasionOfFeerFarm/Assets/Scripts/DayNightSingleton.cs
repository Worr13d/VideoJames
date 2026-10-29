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
    public UnityEvent plantOrHarvest = new UnityEvent();
    public UnityEvent water = new UnityEvent();

    public bool isDay = true; //true for day, false for night
    public int enemiesRemaining;
    public Crops currentCrop;
    public UnityEvent newDay = new UnityEvent();
    public UnityEvent newNight = new UnityEvent();

    //all money currently held by the player
    public int wallet;

    //all the seeds currently held by the player
    public int pumpkinSeeds;
    public int potatoSeeds;
    public int carrotSeeds;
    public int tomatoSeeds;
    public int beans;

    public int cycles;
    private DayNightSingleton()
    {
        //initialize boolean and variables here
        enemiesRemaining = 0;
        cycles = 0;
        currentCrop = Crops.pumpkin;

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

        DontDestroyOnLoad(gameObject);

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
