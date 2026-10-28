using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 2f ;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float bulletLifeSpan = 1.0f ;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;  
    }

    /// <summary>
    /// moves forward relative to current rotation.
    /// </summary>
    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * bulletSpeed;
        if (timer > bulletLifeSpan)
        {
            Destroy(rb.gameObject);
        }

    }

}
