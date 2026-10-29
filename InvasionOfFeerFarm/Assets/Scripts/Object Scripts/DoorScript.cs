using System.Threading;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string scene;
    private float time;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (time > 2f)
        {
            time = 0;
            if (scene == "Farm")
            {
                SceneManager.LoadScene("Home", LoadSceneMode.Additive);

            }
            else
            {
                SceneManager.LoadScene("Farm", LoadSceneMode.Additive);
          
            }
        }
    }
    }
