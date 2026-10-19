using UnityEngine;

public class BedScript : MonoBehaviour
{
    enum DayNightState
    {
        Day,
        Night
    }

    private DayNightState timeOfDay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeOfDay = DayNightState.Day;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// when this object is triggered, it will switch the time of day from day to night or night to day
    /// </summary>
    private void OnTriggerEnter()
    {
        switch (timeOfDay)
        {
            case (DayNightState.Day):
                timeOfDay = DayNightState.Night;
                break;
            case (DayNightState.Night):
                timeOfDay = DayNightState.Day;
                break;
            default:
                break;

        }
    }
}
