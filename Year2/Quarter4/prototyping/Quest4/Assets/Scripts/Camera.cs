using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;         // Het object waar de camera omheen draait
    public float distance = 10f;     // Straal van de rotatie
    public float rotationSpeed = 50f; // Rotatiesnelheid in graden per seconde

    private float currentAngle = 0f;

    void Update()
    {
        // Linksdraaiend (Q)
        if (Input.GetKey(KeyCode.Q))
        {
            currentAngle -= rotationSpeed * Time.deltaTime;
        }

        // Rechtsdraaiend (E)
        if (Input.GetKey(KeyCode.E))
        {
            currentAngle += rotationSpeed * Time.deltaTime;
        }

        // Bepaal nieuwe camera-positie
        Vector3 offset = new Vector3(
            Mathf.Sin(currentAngle * Mathf.Deg2Rad),
            0,
            Mathf.Cos(currentAngle * Mathf.Deg2Rad)
        ) * distance;

        // Update camera
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
