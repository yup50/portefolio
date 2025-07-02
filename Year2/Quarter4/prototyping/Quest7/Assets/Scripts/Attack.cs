using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{ 
    private void OnEnable()
    {
        Invoke("Deactivate", 0.3f); //the attack will be "on" for 0.3s
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyMovement>() != null) //checks if enemy
        {
            Destroy(other.gameObject);
        }
    }
}
