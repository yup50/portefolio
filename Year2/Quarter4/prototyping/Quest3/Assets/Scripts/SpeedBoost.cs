using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private Mover mover;
    private Spawnner spawner;
    // Start is called before the first frame update
    void Start()
    {
        mover = FindAnyObjectByType<Mover>();
        spawner = FindAnyObjectByType<Spawnner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mover.StartCoroutine(mover.ChangeSpeed(15));
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        spawner.isSpawned = false;
    }
}
