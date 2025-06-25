using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int score = 100;
    public ScoreSystem ss;

    private void Start()
    {
        ss = FindAnyObjectByType<ScoreSystem>();
    }

    private void Update()
    {
        if(transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x - 30)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ss.AddScore(score);
            Destroy(gameObject);
        }
    }
}
