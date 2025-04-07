using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speler : MonoBehaviour
{
    float stuur; // Huidige positie van de speler op de x-as
    float xmin; // Linker limiet voor beweging
    float xmax; // Rechter limiet voor beweging

    public float padding = 0.7f; // Voorkomt dat de speler de rand raakt
    public float snelheid; // Beweeg snelheid van de speler

    void Start()
    {
        if (PlayerPrefs.GetString("phoneCheck") == "PC")
        {
            GetComponent<PhoneControls>().enabled = false;
            GetComponent<PhoneShoot>().enabled = false;
        }
        else
        {
            GetComponent<Speler>().enabled = false;
            GetComponent<Shooting>().enabled = false;
        }
        // Bepaal de x-limieten op basis van de schermgrootte
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 meestLinks = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 meestRechts = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = meestLinks.x + padding; // Stel de linkergrens in
        xmax = meestRechts.x - padding; // Stel de rechtergrens in
        Time.timeScale = 0;
    }

    void Update()
    {
        Move(); // Roep de bewegingsfunctie aan
    }

    private void Move()
    {
        // Bereken nieuwe x-positie op basis van input en snelheid
        stuur = Mathf.Clamp((stuur += (Input.GetAxis("Horizontal") * Time.deltaTime * snelheid)), xmin, xmax);
        transform.position = new Vector2(stuur, transform.position.y); // Pas de positie van de speler aan
    }
}
