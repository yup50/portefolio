using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject laser; // De laser die wordt afgevuurd
    public AudioClip shootSound; // Geluidseffect voor het schieten

    private IGeluid _geluid; // Referentie naar een geluidssysteem

    void Start()
    {
        _geluid = FindObjectOfType<AudioManager>(); // Zoek een instantie van AudioManager
    }

    void Update()
    {
        // Controleer of de spatiebalk is ingedrukt en of er geschoten mag worden
        if (Input.GetKeyDown(KeyCode.Space) && CanShoot())
        {
            Fire();
        }
    }

    private void Fire()
    {
        // Speel het schietgeluid af als het bestaat
        if (shootSound != null) _geluid?.SpeelGeluidAf(shootSound);

        // Activeer en positioneer de laser voor het afvuren
        laser.SetActive(true);
        laser.transform.position = GetComponentInParent<Transform>().position + new Vector3(0, 0.5f, 0);
        laser.GetComponent<Bullet>().target = "Enemy"; // Stel het doelwit in als vijanden
        laser.transform.SetParent(null); // Haal de laser los van de speler
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 10f); // Laat de laser omhoog bewegen
    }

    private bool CanShoot()
    {
        return !laser.activeSelf; // Schiet alleen als de laser momenteel niet actief is
    }
}
