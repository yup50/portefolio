using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private const int highScore = 0;

    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.text = $"Score: {score}";
    }
}
