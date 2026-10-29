using UnityEngine;

public class DummyCropBSSCript : MonoBehaviour
{
    public static DummyCropBSSCript instance;

    [SerializeField] public GameObject field;
    [SerializeField] public Vector2 location;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate
        }

        print("this should spawn a plot");
        Instantiate(field, location, Quaternion.identity);
        DontDestroyOnLoad(gameObject);

    }

    private DummyCropBSSCript()
    {
        //initialize boolean and variables here
    }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
