using TMPro;
using UnityEngine;

public class DaysScript : MonoBehaviour
{
    private DayNightSingleton instance;
    [SerializeField] private TextMeshProUGUI text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.isDay)
        {
            gameObject.SetActive(true);
            text.text = "Day " + instance.cycles.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
