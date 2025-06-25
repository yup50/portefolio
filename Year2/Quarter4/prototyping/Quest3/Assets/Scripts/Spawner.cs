using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject speedBoost;
    public bool isSpawned = true;
    private float cd;
    void Start()
    {
        SpawnPowerUp();
        cd = 11;
    }

    private void Update()
    {
        if(cd <= 0)
        {
            SpawnPowerUp();
        }
        if(!isSpawned)
        {
            cd -= Time.deltaTime;
        }
    }
    private void SpawnPowerUp()
    {
        cd = 11;
        isSpawned = true;
        if (GameObject.FindAnyObjectByType<SpeedBoost>() != null) return;
        Vector3 spawnPoint = Vector3.zero;
        int x = Random.Range(0, 4);
        switch (x)
        {
            case 0:
                spawnPoint = new Vector3(9,1,9);
                break;

            case 1:
                spawnPoint = new Vector3(-9, 1, -9);
                break;

            case 2:
                spawnPoint = new Vector3(-9, 1, 9);
                break;

            case 3:
                spawnPoint = new Vector3(9, 1, -9);
                break;

            default:
                Debug.Log("Onverwachte waarde: " + x);
                break;
        }

        Instantiate(speedBoost, spawnPoint, Quaternion.identity);
    }
}
