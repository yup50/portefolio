using System.Collections;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public GameObject bullet;  // De kogel die wordt afgevuurd
    private Transform firePoint; // Punt waar de kogel uit komt
    private float shootInterval; // Tijd tussen schoten
    public float rayDistance = 2.0f;  // Hoe ver de Raycast naar beneden kijkt

    private new void Start()
    {
        base.Start(); // Roep de Start-methode van de parent class aan
        firePoint = transform; // Stel het vuurpunt in op de huidige positie
        shootInterval = Random.Range(2f, 5f); // Willekeurige tijd tussen schoten
        scorePoints *= 1.5f; // Verhoog de scorewaarde van deze vijand
    }

    void Update()
    {
        if (CanShoot()) shootInterval -= Time.deltaTime; // Verlaag de timer als er geschoten kan worden

        // Raycast direct naar beneden om te checken of er een vijand onder staat
        RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.down, rayDistance);

        if (hit.collider == null || !hit.collider.CompareTag("Enemy"))
        {
            // Er staat GEEN vijand onder -> check of we mogen schieten
            if (shootInterval <= 0)
            {
                Shoot();
            }
        }

        // Debug lijn in Scene View om de Raycast zichtbaar te maken
        Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.red);
    }

    private void Shoot()
    {
        // Activeer en positioneer de kogel bij het vuurpunt
        bullet.SetActive(true);
        bullet.transform.position = GetComponentInParent<Transform>().position + new Vector3(0, -0.5f, 0);
        bullet.GetComponent<Bullet>().target = "Player"; // Richt op de speler
        bullet.transform.SetParent(null); // Haal de kogel uit de hiërarchie van de vijand
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f); // Laat de kogel naar beneden bewegen

        // Stel een nieuwe willekeurige schietinterval in
        shootInterval = Random.Range(2f, 5f);
    }

    private bool CanShoot()
    {
        return !bullet.gameObject.activeSelf; // Alleen schieten als de kogel niet actief is
    }
}
