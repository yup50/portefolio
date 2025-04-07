using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 1f; // Hoeveel schade de kogel doet
    public string target; // Doelwit van de kogel ("Enemy" of "Player")

    private void Update()
    {
        // Als de kogel buiten het speelveld is, deactiveer hem
        if (transform.position.y >= 5 || transform.position.y <= -5)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target)) // Controleer of de kogel het juiste doel raakt
        {
            if (target == "Enemy")
            {
                Enemy enemy = collision.GetComponent<Enemy>(); // Haal het Enemy-script op
                if (enemy != null)
                {
                    enemy.TakeDamage(damage); // Verminder de HP van de vijand
                }
            }
            else if (target == "Player")
            {
                collision.GetComponent<HpSystem>().TakeDamage(1); // Verminder de HP van de speler
            }

            gameObject.SetActive(false); // Verwijder de kogel na impact
        }
    }
}
