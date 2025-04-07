using UnityEngine;

public class PhoneControls : MonoBehaviour
{
    public float snelheid = 5f; // Bewegingssnelheid van het object
    private float xmin, xmax; // Beperkingen voor de beweging
    private Vector2 screenCenter; // Middelpunt van het scherm

    public float padding = 0.7f; // Voorkomt dat het object de rand raakt

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft; // Zet het scherm in landschapsmodus

        // Bepaal de horizontale middenlijn van het scherm
        screenCenter = new Vector2(Screen.width / 2, 0);

        // Bereken de grenzen voor beweging op basis van de camera en schermgrootte
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 meestLinks = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 meestRechts = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = meestLinks.x + padding; // Linkergrens met padding
        xmax = meestRechts.x - padding; // Rechtergrens met padding
    }

    void Update()
    {
        HandleTouchInput(); // Verwerk touch-input voor beweging
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0) // Controleer of er een aanraking is
        {
            Touch touch = Input.GetTouch(0); // Pak de eerste aanraking

            // Controleer of het een nieuwe aanraking of een vastgehouden aanraking is
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                // Alleen reageren als de aanraking in het onderste kwart van het scherm is
                if (touch.position.y <= Screen.height / 4)
                {
                    if (touch.position.x < screenCenter.x)
                        MoveLeft(); // Beweeg naar links als aanraking links is
                    else
                        MoveRight(); // Beweeg naar rechts als aanraking rechts is
                }
            }
        }
    }

    // Beweeg het object naar links binnen de grenzen
    void MoveLeft()
    {
        float newX = Mathf.Clamp(transform.position.x - (snelheid * Time.deltaTime), xmin, xmax);
        transform.position = new Vector2(newX, transform.position.y);
    }

    // Beweeg het object naar rechts binnen de grenzen
    void MoveRight()
    {
        float newX = Mathf.Clamp(transform.position.x + (snelheid * Time.deltaTime), xmin, xmax);
        transform.position = new Vector2(newX, transform.position.y);
    }
}
