using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private ScoreText scoreText;
    public int score;
    // Start is called before the first frame update

    private void Start()
    {
        scoreText = FindAnyObjectByType<ScoreText>();
        Debug.Log(scoreText);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            scoreText.AddScore(score);
            Destroy(gameObject);
        }
    }
}
