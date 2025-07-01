// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private Sprite[] groundSprites;
    [SerializeField] private GameObject rockTilePrefab;
    [SerializeField] private Sprite[] rockSprites;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Sprite[] foodSprites;
    [SerializeField] private GameObject exitPrefab;
    [SerializeField] private int amountOfEnemies;
    [SerializeField] private GameObject enemyPrefab;

    private int exitLocation;


    void Start()
    {
        GenerateFloor();
        SpawnExit();
        SpawnEnemies();
    }

    private void GenerateFloor()
    {
        for (int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                InstantiateFloorTile(x, y);
            }
        }
        GenerateExit();
    }

    private void InstantiateFloorTile(int x, int y, bool spawnExit = false)
    {
        GameObject newFloorTile;
        if (spawnExit)
        {
            newFloorTile = Instantiate(groundTilePrefab, new Vector2(x, y), Quaternion.identity);
        }
        newFloorTile = Instantiate(groundTilePrefab, new Vector2(x, y), Quaternion.identity);
        newFloorTile.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];
        int rockSpawnVariabel = Random.Range(0, 10);
        int foodSpawnVariabel = Random.Range(0, 25);
        if (x == 0 || x == 19 || y == 0 || y == 19 || rockSpawnVariabel == 0)
        {
            newFloorTile = Instantiate(rockTilePrefab, new Vector2(x, y), Quaternion.identity);
            newFloorTile.GetComponent<SpriteRenderer>().sprite = rockSprites[Random.Range(0, rockSprites.Length)];
        } else if(foodSpawnVariabel == 0)
        {
            newFloorTile = Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
            newFloorTile.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];
        } 
    }
    
    private void GenerateExit()
    {
        int exitSpawnVariabel = Random.Range(0, 4);
        if(exitSpawnVariabel == 0)
        {

        }
    }

    private void SpawnExit()
    {
        // Challenge 2
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            Vector2 spawnLocation = new Vector2(Random.Range(0, 19), Random.Range(0, 19));
            GameObject newEnemy = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }
    }
}
