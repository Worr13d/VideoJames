using UnityEngine;

public class EvilCropDestoryIfCopy : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static EvilCropDestoryIfCopy Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Otherwise, make this the official instance
        Instance = this;

        // Optional: Keep it alive across scenes if needed
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
