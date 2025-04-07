using UnityEngine;

public class PhoneShoot : MonoBehaviour
{
    public GameObject laser;

    public AudioClip shootSound;

    private IGeluid _geluid;

    private void Start()
    {
        _geluid = FindObjectOfType<AudioManager>(); // Zoek een instantie van een AudioManager

    }
    void Update()
    {
        if (Application.isEditor)
        {
            SimulateTouchWithMouse(); // Testen met muis in Unity Editor
        }
        else
        {
            HandleTouchInput(); // Touch input op mobiel
        }
    }


    //Deze methode regelt dat je schiet wanneer je op je telefoon in de bovenste 75% procent op je scherm tikt
    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && touch.position.y > Screen.height / 4)
            {
                if (CanShoot()) Fire();
            }
        }
    }

    //hulp methode voor testen. zet muisklik om naar touchscreen tap
    void SimulateTouchWithMouse()
    {
        if (Input.GetMouseButtonDown(0)) // Klik met muis
        {
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.y > Screen.height / 4) // Alleen schieten boven onderste 25%
            {
                if (CanShoot()) Fire();
            }
        }
    }

    //methode die gebruikt wordt voor het vuren
    private void Fire()
    {
        if (shootSound != null) _geluid?.SpeelGeluidAf(shootSound);

        laser.SetActive(true);
        laser.transform.position = transform.position + new Vector3(0, 0.5f, 0);
        laser.GetComponent<Bullet>().target = "Enemy";
        laser.transform.SetParent(null);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f);
    }


    //1 van de verreiste om te vuren. Je vorige schot moet gedespawned zijn
    private bool CanShoot()
    {
        return !laser.activeSelf;
    }
}
