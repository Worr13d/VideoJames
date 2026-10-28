using TMPro;
using UnityEngine;

public class EnemiesRemainingScript : MonoBehaviour
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
            text.text = "";
        }
        else
        {
            text.text = "enemies remaining: " + instance.enemiesRemaining;
        }
    }
}
