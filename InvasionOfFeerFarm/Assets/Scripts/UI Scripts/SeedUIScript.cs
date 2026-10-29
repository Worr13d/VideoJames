using TMPro;
using UnityEngine;

public class SeedUIScript : MonoBehaviour
{

    [SerializeField] string typeOfSeed;
    [SerializeField] TextMeshProUGUI text;
    private DayNightSingleton instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;

    }

    // Update is called once per frame
    void Update()
    {
        typeOfSeed.ToLower().Trim();
        if (typeOfSeed == "pumpkin")
        {
            text.text = instance.pumpkinSeeds.ToString();
        }
        else if (typeOfSeed == "potato")
        {
            text.text = instance.potatoSeeds.ToString();
        }
        else if (typeOfSeed == "carrot")
        {
            text.text = instance.carrotSeeds.ToString();
        }
        else if (typeOfSeed == "tomato")
        {
            text.text = instance.tomatoSeeds.ToString();
        }
        else if (typeOfSeed == "bean")
        {
            text.text = instance.beans.ToString();
        }
        else
        {
            text.text = "error - invalid serialized field";
        }



    }
}
