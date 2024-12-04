using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraPosition;
    public float sensitivityX;
    public float sensitivityY;
    public Transform orientation;
    private float xRotation;
    private float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Update camera position to match the assigned position (e.g., player head)
        transform.position = cameraPosition.position;

        // Mouse input for camera rotation
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivityY;

        // Update rotation values
        yRotation += mouseX;
        xRotation -= mouseY;

        // Clamp xRotation to avoid flipping
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Rotate the camera and orientation (useful for player movement direction)
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        // Optional: Draw a debug ray for interaction
        Debug.DrawRay(transform.position, transform.forward * 50, Color.green);
    }
}
