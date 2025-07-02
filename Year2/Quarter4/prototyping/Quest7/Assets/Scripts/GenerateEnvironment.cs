// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private int size; //the max value of the size of the terrain

    public Transform terrain;
    public Transform food;

    private int exitLocation;
    private HashSet<Vector2Int> occupiedPositions = new HashSet<Vector2Int>();
    public GameObject right, top; //the borders



    void Start()
    {
        size = Random.Range(15, 41);
        top.transform.position = new Vector3(top.transform.position.x, size, 0);
        right.transform.position = new Vector3(size, right.transform.position.y, 0);
        GenerateFloor();
        SpawnExit();
        SpawnEnemies();
    }

    private void GenerateFloor()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                InstantiateFloorTile(x, y);
            }
        }
    }

    private void InstantiateFloorTile(int x, int y, bool spawnExit = false)
    {
        GameObject newFloorTile;
        int rockSpawnVariabel = Random.Range(0, 10); //variabel that wil spawn the walls and obstacles
        int foodSpawnVariabel = Random.Range(0, 25); //variabel that wil food stuff
        if (spawnExit) //just using the logic here to also spawn the exit. but only used once
        {
            newFloorTile = Instantiate(exitPrefab, new Vector2(x, y), Quaternion.identity);
            return;
        }
        newFloorTile = Instantiate(groundTilePrefab, new Vector2(x, y), Quaternion.identity);
        newFloorTile.GetComponent<SpriteRenderer>().sprite = groundSprites[Random.Range(0, groundSprites.Length)];
        newFloorTile.transform.SetParent(terrain.transform, false);
        if (x == 10 && y == 10)
        {
            return; //this is de playerspawn. Don't want anything to spawn here
        }
        else if (x == 0 || x == size - 1 || y == 0 || y == size - 1 || rockSpawnVariabel == 0)
        {
            newFloorTile = Instantiate(rockTilePrefab, new Vector2(x, y), Quaternion.identity);
            newFloorTile.GetComponent<SpriteRenderer>().sprite = rockSprites[Random.Range(0, rockSprites.Length)];
            newFloorTile.transform.SetParent(terrain.transform, false);
            occupiedPositions.Add(new Vector2Int(x, y));
        }
        else if (foodSpawnVariabel == 0)
        {
            newFloorTile = Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
            newFloorTile.GetComponent<SpriteRenderer>().sprite = foodSprites[Random.Range(0, foodSprites.Length)];
            newFloorTile.transform.SetParent(food.transform, false);
        }
    }
    
    private void SpawnExit()
    {
        int exitSpawnVariabel = Random.Range(0, 4);
        if(exitSpawnVariabel == 0)
        {
            InstantiateFloorTile(1, 1, true);
        }else if(exitSpawnVariabel == 1)
        {
            InstantiateFloorTile(size -2, 1, true);
        }else if(exitSpawnVariabel == 1)
        {
            InstantiateFloorTile(size - 2, size - 2, true);
        }
        else
        {
            InstantiateFloorTile(1, size - 2, true);
        }
    }

    private void SpawnEnemies()
    {
        int enemiesSpawned = 0;
        int[] allowedValues = Enumerable.Range(0, size - 1)
            .Where(x => x < 8 || x > 10)
            .ToArray();
        while (enemiesSpawned < amountOfEnemies)
        {
            
            Vector2Int spawnLocation = new Vector2Int(allowedValues[Random.Range(0, allowedValues.Length)], allowedValues[Random.Range(0, allowedValues.Length)]);
            if (!occupiedPositions.Contains(spawnLocation))
            {
                GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(spawnLocation.x, spawnLocation.y , 0), Quaternion.identity);
                occupiedPositions.Add(spawnLocation);
                enemiesSpawned++;
            }
        }
    }
}
