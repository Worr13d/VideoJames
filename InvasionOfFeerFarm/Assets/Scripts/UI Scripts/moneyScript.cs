using TMPro;
using UnityEngine;

public class moneyScript : MonoBehaviour
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
        text.text = instance.money.ToString();
    }
}
