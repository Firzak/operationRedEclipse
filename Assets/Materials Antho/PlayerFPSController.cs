using UnityEngine;

public class PlayerFPSController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Cache le curseur
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotation horizontale du corps
        transform.Rotate(Vector3.up * mouseX);

        // Rotation verticale de la caméra (limité)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
