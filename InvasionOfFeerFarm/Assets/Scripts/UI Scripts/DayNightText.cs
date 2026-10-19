using TMPro;
using UnityEngine;
public enum TimeOfDay
{
    Day,
    Night
}

public class DayNightText : MonoBehaviour
{
   
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isDay;

    public bool IsDay
    {
        get { return isDay; }
        set { isDay = value; }
    }

    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        isDay = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (isDay)
        {
            text.text = "Day";
        }
        else
        {
            text.text = "Night";
        }
    }
    
}
