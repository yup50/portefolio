using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage = 1;  // Schade die de kogel toebrengt

    // Zorg dat de bullet iets sneller verdwijnt als er geen impact is
    public float lifeTime = 10f;

    private void Start()
    {
        // Vernietig de kogel na de ingestelde levensduur om de performance te optimaliseren
        Destroy(gameObject, lifeTime);
    }

    // Deze functie wordt aangeroepen als de kogel iets raakt met een trigger
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"));
        {
            EnemyController enemy = other.GetComponent<EnemyController>();
            enemy.Damage(damage);  // Roept de TakeDamage-functie aan van de vijand
            Debug.Log("Enemy geraakt! Schade toegebracht: " + damage);
            Destroy(gameObject);

        }

        // Verwijder de kogel nadat hij een object raakt
    }
}
