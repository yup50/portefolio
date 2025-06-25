using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform teleportTarget;
    [SerializeField] GameObject player;
    [SerializeField] Light areaLight;
    [SerializeField] Light mainWorldLight;
    public bool multi;
    public List<GameObject> teleporters = new List<GameObject>();

    void Start() 
    {
        StartCoroutine(BlinkWorldLight());
        player = GameObject.FindGameObjectWithTag("Player");
        // CHALLENGE TIP: Make sure all relevant lights are turned off until you need them on
        // because, you know, that would look cool.
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (multi)
            {
                TeleportPlayerRandom(other.gameObject);
            }
            else
            {
                TeleportPlayer(other.gameObject);  //challenge 2
                DeactivateObject(); // Challenge 3: DeactivateObject();
            }
            IlluminateArea();
        }
        // Challenge 4: IlluminateArea();
        // Challenge 5: StartCoroutine ("BlinkWorldLight");
        // Challenge 6: TeleportPlayerRandom();
    }

    void TeleportPlayer(GameObject other)
    {
        other.transform.position = teleportTarget.position + new Vector3(0, 1, 0);
    }

    void DeactivateObject()
    {
        this.gameObject.SetActive(false);         
    }

    void IlluminateArea()
    {
        if(areaLight != null) areaLight.gameObject.SetActive(true);
    }

    IEnumerator BlinkWorldLight()
    {
        while(mainWorldLight != null)
        {
            mainWorldLight.intensity = 1;
            yield return new WaitForSeconds(2f);
            mainWorldLight.intensity = 0;
            yield return new WaitForSeconds(10f);
        }
    }

    void TeleportPlayerRandom(GameObject other)
    {
        if(teleporters.Count > 0)
        {
            int x = Random.Range(0, teleporters.Count);
            other.transform.position = teleporters[x].transform.position + new Vector3(0, 1, 0);
        }
    }

}
