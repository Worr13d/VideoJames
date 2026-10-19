using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 velocity;
    private Vector2 position;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //handles rotation
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 direction2 = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);
        float angle = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (rb.rotation > 90 || rb.rotation < -90)
        {
            rb.gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            rb.gameObject.GetComponent<SpriteRenderer>().flipY = false;

        }
    }

    private void FixedUpdate()
    {
        //basic movement
        velocity = direction.normalized * speed;
        position = rb.position + velocity * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        direction = ctx.ReadValue<Vector2>();
    }
}
