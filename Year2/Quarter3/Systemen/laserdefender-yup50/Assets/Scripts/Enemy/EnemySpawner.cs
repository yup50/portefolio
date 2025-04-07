using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool movingRight = true;
    public float speed = 2.5f;

    public float width = 14f;
    public float height = 6f;

    float xmin, xmax;


    // Start is called before the first frame update

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Zet de kleur naar rood
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 2f), new Vector3(width, height));
    }
    void Start()
    {
        //alles hierin zet de grenzen van het speelveld
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundry = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBoundry = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftBoundry.x;
        xmax = rightBoundry.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeFormation = transform.position.x + (0.5f * width);
        float leftEdgeFormation = transform.position.x - (0.5f * width);

        if (leftEdgeFormation <= xmin)
        {
            movingRight = true;
        }
        else if (rightEdgeFormation >= xmax)
        {
            movingRight = false;
        }
    }
}
