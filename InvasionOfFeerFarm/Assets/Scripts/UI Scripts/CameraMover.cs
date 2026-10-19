using UnityEngine;
/// <summary>
/// Sticks the camera to the player
/// </summary>
public class CameraMover : MonoBehaviour
{
    [SerializeField] Transform playerPosition;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //does the sticking
        Vector3 holdingPosition = playerPosition.position;
        holdingPosition.z = -10;
        transform.position = holdingPosition;
    }
}
