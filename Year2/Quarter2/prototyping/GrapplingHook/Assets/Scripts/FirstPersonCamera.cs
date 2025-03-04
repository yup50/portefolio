using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    public float mouseSensitivity = 100f;
    public Transform playerBody; // Referentie naar de spelerobject (bijv. parent van de camera)

    private float xRotation = 0f;

    void Start()
    {
        // Zorg dat de cursor niet zichtbaar is en vastzit in het scherm
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        // Lees muisinput
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Beperk de verticale rotatie van de camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Pas de rotatie toe op de camera (voorop/achterover kijken)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Draai het spelerobject horizontaal (links/rechts kijken)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
