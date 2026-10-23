using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

    }
}
