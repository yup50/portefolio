using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpDrone : MonoBehaviour
{
    public int x; // Drempelwaarde voor HP om drone onzichtbaar te maken
    private SpriteRenderer rend; // Referentie naar de SpriteRenderer
    private HpSystem sys; // Referentie naar het HP-systeem van de ouder

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>(); // Haal de SpriteRenderer op
        sys = GetComponentInParent<HpSystem>(); // Zoek het HP-systeem in de ouder
    }

    void Update()
    {
        // Als de HP van de ouder lager of gelijk is aan x, maak de sprite onzichtbaar
        if (sys.Hp() <= x)
        {
            rend.color = new Color(1f, 1f, 1f, 0f); // Volledig transparant
        }
    }
}
