using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class triggerPoint : MonoBehaviour
{
    private DayNightSingleton instance;
    [SerializeField] private GameObject thisObject;
    [SerializeField] private GameObject cropPrefab;

    void Start()
    {
        thisObject.SetActive(false);
        instance = DayNightSingleton.instance;

        //triggers when attempting Harvest() in player
        instance.plantOrHarvest.AddListener(ToggleTrigger);
    }

    /// <summary>
    /// Switches the game object on
    /// </summary>
    public void ToggleTrigger()
    {
        thisObject.SetActive(true);
        print("trigger toggled in point 1");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger started point 1");
        //if the collision is with a plot and it's day
        if (collision.gameObject.TryGetComponent<CropPlotScript>(out CropPlotScript plotScript) && instance.isDay)
        {
            if (plotScript.isFilled == false)
            {
                Transform plotTransform = collision.gameObject.GetComponent<Transform>();
                Vector3 plotPosition = plotTransform.position;

                //reduces the number of held relevant seeds by 1 if possible
                bool canPlant = false;
                switch (instance.currentCrop)
                {
                    case Crops.pumpkin:
                        if (instance.pumpkinSeeds > 0)
                        {
                            instance.pumpkinSeeds--;
                            canPlant = true;
                        }
                        else
                        {
                            instance.currentCrop = Crops.bean;
                        }
                            break;
                        
                    case Crops.bean:
                        if (instance.beans > 0)
                        {
                            instance.beans--;
                            canPlant = true;
                        }
                        else
                        {
                            instance.currentCrop = Crops.carrot;
                        }

                        break;
                    case Crops.carrot:
                        if (instance.carrotSeeds > 0)
                        {
                            instance.carrotSeeds--;
                            canPlant = true;
                        }
                        else
                        {
                            instance.currentCrop = Crops.potato;
                        }

                        break;
                    case Crops.potato:
                        if (instance.potatoSeeds > 0)
                        {
                            instance.potatoSeeds--;
                            canPlant = true;
                        }
                        else
                        {
                            instance.currentCrop = Crops.tomato;
                        }

                        break;
                    case Crops.tomato:
                        if (instance.tomatoSeeds > 0)
                        {
                            instance.tomatoSeeds--;
                            canPlant = true;
                        }
                        else
                        {
                            instance.currentCrop = Crops.pumpkin;
                        }
                        break;

                }


                //instantiates a crop at plotPosition
                if (canPlant)
                {
                    Instantiate(cropPrefab, plotPosition, Quaternion.identity);
                    plotScript.isFilled = true;
                    canPlant = false;
                }

            }
        }

        //if colliding with a crop and it's day
        if (collision.gameObject.TryGetComponent<CropScript>(out CropScript cropScript) && instance.isDay)
        {
            print("CropScript collision point 1");
            //if the crop is grown
            if (cropScript.State == CropScript.CropState.grown)
            {
                //harvest it
                instance.money += cropScript.Value;
                Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
            }
        }

        //turns the object back off when done
        thisObject.SetActive(false);
    }

    /// <summary>
    /// handles the planting and harvesting of crops
    /// </summary>
    /// <param name="collision">the thing the thing is colliding with</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("collision started point 1");
        //if the collision is with a plot and it's day
        if (collision.gameObject.TryGetComponent<CropPlotScript>(out CropPlotScript plotScript) && instance.isDay)
        {
            if (plotScript.isFilled == false)
            {
                Transform plotTransform = collision.gameObject.GetComponent<Transform>();
                Vector3 plotPosition = plotTransform.position;

                //reduces the number of held relevant seeds by 1 if possible
                bool canPlant = false;
                switch (instance.currentCrop)
                {
                    case Crops.pumpkin:
                        if (instance.pumpkinSeeds > 0)
                        {
                            instance.pumpkinSeeds--;
                            canPlant = true;
                        }

                        break;
                    case Crops.bean:
                        if (instance.beans > 0)
                        {
                            instance.beans--;
                            canPlant = true;
                        }

                        break;
                    case Crops.carrot:
                        if (instance.carrotSeeds > 0)
                        {
                            instance.carrotSeeds--;
                            canPlant = true;
                        }

                        break;
                    case Crops.potato:
                        if (instance.potatoSeeds > 0)
                        {
                            instance.potatoSeeds--;
                            canPlant = true;
                        }

                        break;
                    case Crops.tomato:
                        if (instance.tomatoSeeds > 0)
                        {
                            instance.tomatoSeeds--;
                            canPlant = true;
                        }

                        break;
                }


                //instantiates a crop at plotPosition
                if (canPlant)
                {
                    Instantiate(cropPrefab, plotPosition, Quaternion.identity);
                    plotScript.isFilled = true;
                    canPlant = false;
                }

            }
        }

        //if colliding with a crop and it's day
        if (collision.gameObject.TryGetComponent<CropScript>(out CropScript cropScript) && instance.isDay)
        {
            print("CropScript collision point 1");
            //if the crop is grown
            if (cropScript.State == CropScript.CropState.grown)
            {
                //harvest it
                instance.money += cropScript.Value;
                Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
            }
        }

        //turns the object back off when done
        thisObject.SetActive(false);
    }

    
}
