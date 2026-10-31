using UnityEngine;

public class triggerThree : MonoBehaviour
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
        print("trigger toggled in point 3");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if colliding with a crop and it's day
        if (collision.gameObject.TryGetComponent<CropScript>(out CropScript cropScript) && instance.isDay)
        {

            //if the crop is grown
            if (cropScript.State == CropScript.CropState.grown)
            {
                //harvest it
                instance.money += cropScript.Value;
                Destroy(collision.gameObject.GetComponent<SpriteRenderer>());
                print("crop harvested");
            }
            print("trigger point 3 crop harvest attempt");
        }

        //turns the object back off when done
        thisObject.SetActive(false);
    }
}
