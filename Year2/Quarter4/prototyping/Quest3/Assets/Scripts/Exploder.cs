using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Mover mover = other.GetComponent<Mover>();
            mover.StartCoroutine(mover.SlowTime());
            mover.PlaySound();
            print("Aww, you got me");
            Destroy(gameObject);
        }
    }

    public void RandomPlacer()
    {
        float x = Random.Range(-9, 9);
        if (x < 0.5f && x > -2.5f) x = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, x);
    }
}
