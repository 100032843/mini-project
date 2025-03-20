using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    private Vector3 offset;

    // Rotation speed of the camera around the player.
    public float rotationSpeed = 5f;

    // Start is called before the first frame update.
    void Start()
    {
        // Calculate the initial offset between the camera and the player                                          
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame ...
    // ...after all Update functions have been completed.
    void LateUpdate()
    {
        // Maintain the same offset between the camera and player throughout
        transform.position = player.transform.position + offset; 

        // Calculate the rotation based on mouse input.
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        Quaternion rotation = Quaternion.Euler(0, mouseX, 0);

        // Apply rotation to the offset.
        offset = rotation * offset;

        // Make the camera look at the player.
        transform.LookAt(player.transform);
    }
}


