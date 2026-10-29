using UnityEngine;

public class ObliterateImposter : MonoBehaviour
{
    [SerializeField] private string name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject person = GameObject.Find(name);
        if (person.gameObject != this.gameObject)
        {
            Destroy(person);
        }
    }
}
