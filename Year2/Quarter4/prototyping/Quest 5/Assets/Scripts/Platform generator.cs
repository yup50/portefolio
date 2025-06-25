using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class Platformgenerator : MonoBehaviour
{
    public List<Transform> platforms = new List<Transform>();
    private Transform player;
    public float spawnDistance = 15f;
    public float minXGap = 0f;
    public float maxXGap = 4f;
    int currentIndex = 0;
    int Index = 5;


    private float lastSpawnX;
    // Start is called before the first frame update
    void Awake()
    {
        // Vul de lijst met alle children van dit object
        foreach (Transform child in transform)
        {
            platforms.Add(child);
        }

        // Sorteer de lijst op x-positie, van links naar rechts
        platforms = platforms.OrderBy(p => p.position.x).ToList();
        for (int i = 0; i < platforms.Count; i++)
        {
            platforms[i].SetSiblingIndex(i);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        lastSpawnX = 150;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (player.position.x + spawnDistance >= lastSpawnX)
        {
            SpawnPlatform();
            SpawnPlatformForPlayer();
        }
    }

    private void SpawnPlatform()
    {
        float gap = Random.Range(minXGap, maxXGap);
        float yOffset = Random.Range(player.position.y - 4, player.position.y + 4);

        Vector3 newPos = new Vector3(lastSpawnX + gap, yOffset, 0f);
        platforms[currentIndex].position = newPos;
        platforms[currentIndex].gameObject.SetActive(false); //zorgt voor de coinspawn
        platforms[currentIndex].gameObject.SetActive(true);

        lastSpawnX = newPos.x + 8;

        currentIndex = (currentIndex + 1) % platforms.Count;
    }

    private void SpawnPlatformForPlayer()
    {
        float gap = Random.Range(minXGap, maxXGap);
        float yOffset = Random.Range(player.position.y - 1, player.position.y + 1);

        Vector3 newPos = new Vector3(lastSpawnX + gap, yOffset, 0f);
        platforms[currentIndex].gameObject.SetActive(false); //zorgt voor de coinspawn
        platforms[currentIndex].gameObject.SetActive(true);
        
        platforms[Index].position = newPos;

        Index = (Index + 1) % platforms.Count;
    }
}
