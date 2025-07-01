using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int totalScore;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
        UpdateScore();
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score: {totalScore} points";
    }
}
