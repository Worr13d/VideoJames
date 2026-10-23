using System;
using UnityEngine;

public class CropPlotScript : MonoBehaviour
{
    //singleton 
    DayNightSingleton instance;

    //watered state
    [SerializeField] private bool isWatered;

    //unwatered and watered sprite
    [SerializeField] private Sprite unwatered;
    [SerializeField] private Sprite watered;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = DayNightSingleton.instance;

        instance.newDay.AddListener(SwitchWatered);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SwitchWatered()
    {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = unwatered;
    }
}
