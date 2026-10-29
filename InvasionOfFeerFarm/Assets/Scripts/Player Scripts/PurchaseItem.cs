using UnityEngine;

public class PurchaseItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private DayNightSingleton instance;

    void Start()
    {
        instance = DayNightSingleton.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchasePumpkin()
    {
        if (instance.money >= 1)
        {
            instance.money--;
            instance.pumpkinSeeds++;

        }
    }
    public void PurchasePotato()
    {
        if (instance.money >= 2)
        {

            instance.money -= 2;
            instance.potatoSeeds++;
        }
    }
    public void PurchaseCarrot()
    {
        if (instance.money >= 5)
        {

            instance.money -= 5;
            instance.carrotSeeds++;
        }
    }
    public void PurchaseTomato()
    {
        if (instance.money >= 10)
        {

            instance.money -= 10;
            instance.tomatoSeeds++;
        }
    }
    public void PurchaseBeans()
    {
        if (instance.money >= 25)
        {

            instance.money -= 25;
            instance.beans++;
        }
        }
    }
