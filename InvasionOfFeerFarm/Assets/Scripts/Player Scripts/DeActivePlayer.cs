using UnityEngine;
using UnityEngine.SceneManagement;

public class DeActivePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Always unsubscribe to prevent memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Deactivate this object as soon as a new scene finishes loading
        if (scene.name == "Farm")
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);

        }
    }
}
