using UnityEngine;

public class InsidePlayerOnlyScript : MonoBehaviour
{
    [SerializeField] GameObject shop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "table")
        {
            shop.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "table")
        {
            shop.SetActive(false);
        }
    }
}
