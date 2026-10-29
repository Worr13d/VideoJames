using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class BedScript : MonoBehaviour
{
    private DayNightSingleton instance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// when this object is triggered, it will switch the time of day from day to night or night to day
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == "playerTest2")
        {
        //changes it to night
        if (instance.isDay)
        {
           instance.isDay = false;
           instance.newNight.Invoke();
          
        }
        //changes it to day
        else
        {
            if (instance.enemiesRemaining == 0)
                {
                    instance.isDay = true;
                    instance.newDay.Invoke();
                    instance.cycles++;
                    instance.health++;
                }
            }
        }

    }



}
