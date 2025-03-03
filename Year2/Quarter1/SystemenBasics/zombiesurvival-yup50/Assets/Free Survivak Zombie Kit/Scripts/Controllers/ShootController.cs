using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour
{
    [Header("Weapon UI Settings")]
    public GameObject WeaponUI;       // UI voor wapens
    public Text bulletNumberUI;       // UI tekst voor kogels

    [Header("Weapon Settings")]
    public int bulletsLeft = 10;      // Aantal kogels dat je hebt
    public int maxBullets = 10;       // Maximum aantal kogels
    public GameObject bulletPrefab;   // De prefab voor de kogel
    public Transform firePoint;       // Het punt waar de kogel wordt afgevuurd
    public float bulletSpeed = 5f;    // De snelheid van de kogel

    // Privates
    private bool canShoot = false;    // Variabele om bij te houden of de HUD aan staat en er geschoten kan worden

    private void Start()
    {
        // Verberg de Weapon UI bij start
        WeaponUI.SetActive(false);
        UpdateWeaponUI();
    }

    void Update()
    {
        // Toggle Weapon HUD aan of uit als je op "H" drukt
        if (Input.GetKeyDown(KeyCode.H))
        {
            WeaponUI.SetActive(!WeaponUI.activeSelf);
            canShoot = WeaponUI.activeSelf;  // Kan alleen schieten als HUD actief is
            UpdateWeaponUI();
        }

        // Schiet als je op "K" drukt, de HUD aanstaat en je kogels hebt
        if (Input.GetKeyDown(KeyCode.K) && canShoot && bulletsLeft > 0)
        {
            Shoot();
        }

        // Herladen als je op "R" drukt
        if (Input.GetKeyDown(KeyCode.R) && canShoot)
        {
            Reload();
        }
    }

    // Functie voor het schieten
    void Shoot()
    {
        bulletsLeft--;  // Verminder kogels bij schot
        Debug.Log("Bang! Kogels over: " + bulletsLeft);

        // Spawn de kogel prefab op het firePoint en geef het een snelheid
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        if (bulletRb != null)
        {
            bulletRb.velocity = firePoint.forward * bulletSpeed;  // Beweeg de kogel vooruit
        }

        UpdateWeaponUI();  // Update de UI na het schot
    }

    // Functie voor herladen
    void Reload()
    {
        int bulletsNeeded = maxBullets - bulletsLeft;  // Bereken hoeveel kogels nodig zijn
        if (bulletsNeeded > 0)
        {
            bulletsLeft = maxBullets;  // Vul de kogels aan tot het maximum
            Debug.Log("Herladen... Kogels aangevuld tot: " + bulletsLeft);
            UpdateWeaponUI();
        }
        else
        {
            Debug.Log("Maximale kogels al bereikt!");
        }
    }

    // Update de HUD met het aantal kogels
    void UpdateWeaponUI()
    {
        if (WeaponUI.activeSelf)
        {
            bulletNumberUI.text = "Bullets: " + bulletsLeft.ToString() + "/" + maxBullets.ToString();
        }
    }
}
