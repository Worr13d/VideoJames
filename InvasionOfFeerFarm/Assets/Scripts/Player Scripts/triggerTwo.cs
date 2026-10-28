using UnityEngine;

public class triggerTwo : MonoBehaviour
{
    private DayNightSingleton instance;
    [SerializeField] GameObject thisObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisObject.SetActive(false);
        instance = DayNightSingleton.instance;

        instance.water.AddListener(Water);
    }

    

    public void Water()
    {
        
        thisObject.SetActive(true);
        print("Water triggered point 2");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CropPlotScript>(out CropPlotScript plotScript))
        {
            plotScript.SwitchWatered();
        }
        thisObject.SetActive(false);
        print("ontriuggeerenter triggered point 2");
    }

    public void OnCollisionStay(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent<CropPlotScript>(out CropPlotScript plotScript))
        {
            plotScript.SwitchWatered();
        }
        thisObject.SetActive(false);
        print("Oncollisionstay triggered point 2");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.TryGetComponent<CropPlotScript>(out CropPlotScript plotScript))
        {
            plotScript.SwitchWatered();
        }
        thisObject.SetActive(false);
        print("Oncollisionenter triggered 2");
    }
}
