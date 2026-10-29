using UnityEngine;

public class HideDuringDay : MonoBehaviour
{
    private DayNightSingleton instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;


    }

    // Update is called once per frame
    private void Update()
    {
        if (instance.isDay)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
