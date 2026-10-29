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
    private SpriteRenderer bigRender;
    public bool isFilled;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        instance = DayNightSingleton.instance;

        instance.newDay.AddListener(SwitchUnwatered);

        bigRender = gameObject.GetComponent<SpriteRenderer>();

        SwitchUnwatered();

        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// used in a listener only to dry the cropplot on a new morning
    /// </summary>
    private void SwitchUnwatered()
    {
        bigRender.sprite = unwatered;
    }

    /// <summary>
    /// called through a getcomponent in onshoot of the player class during the day when interacting
    /// </summary>
    public void SwitchWatered()
    {
        bigRender.sprite = watered;
    }
}
