using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Screenmanager sm;
    public GameObject testPre;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    private GameObject player;
    private float spawnRate = 2f;

    [Header("power-ups")]
    public List<GameObject> powerUps = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>().gameObject;
        InvokeRepeating("SpawnEnemy", 2f, spawnRate);
        InvokeRepeating("SpawnPower", 2f, spawnRate * 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        int border = Random.Range(1, 5);
        float xPos = 0;
        float yPos = 0;
        if (border == 1 || border ==  2)
        {
            xPos = Random.Range(sm.minX, sm.maxX);
            if (border == 1) yPos = sm.maxY;
            if (border == 2) yPos = sm.minY;
        }

        if (border == 3 || border == 4)
        {
            yPos = Random.Range(sm.minY, sm.maxY);
            if (border == 3) yPos = sm.maxX;
            if (border == 4) yPos = sm.minX;
        }
        
        GameObject enemy = Instantiate(testPre, new Vector2(xPos * 1.2f, yPos * 1.2f), Quaternion.identity);
        enemy.GetComponent<Enemy>().target = player;

    }


    private void SpawnPower()
    {
        if (FindObjectOfType<Temp>() != null)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUps.Count);
        GameObject selectedPowerUp = powerUps[randomIndex];

        Vector2 spawnPosition = new Vector2(Random.Range(sm.minX + 2, sm.maxX - 2), Random.Range(sm.minY + 2, sm.maxY - 2));
        Instantiate(selectedPowerUp, spawnPosition, Quaternion.identity);
    }

}
