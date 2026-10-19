using TMPro;
using UnityEngine;

public class DayNightText : MonoBehaviour
{
    enum DayNightState
    {
        Day,
        Night
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DayNightState timeOfDay;

    [SerializeField] private TextMeshProUGUI text;

    void Start()
    {
        timeOfDay = DayNightState.Day;
    }

    // Update is called once per frame
    void Update()
    {
        switch (timeOfDay)
        {
            case(DayNightState.Day):
                text.text = "Day";
                break;

            case(DayNightState.Night):
                text.text = "Night";
                break;
            default:
                break;

        }
    }
}
