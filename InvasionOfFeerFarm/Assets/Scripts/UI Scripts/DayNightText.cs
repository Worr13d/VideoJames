using TMPro;
using UnityEngine;


public class DayNightText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    private DayNightSingleton instance;

    void Start()
    {
        instance = DayNightSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
       if (instance.isDay)
        {
            text.text = "Day";
        }
        else
        {
            text.text = "Night";
        }
    }
    
}
