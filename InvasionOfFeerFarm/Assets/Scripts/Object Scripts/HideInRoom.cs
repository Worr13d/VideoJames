using UnityEngine;
using UnityEngine.SceneManagement;

public class HideInRoom : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Home")
        {
            gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Home")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);

        }
    }
}
