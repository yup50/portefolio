using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI-element voor de score
    private float score; // Huidige score van de speler

    void Start()
    {
        ResetScore();
    }

    private void Update()
    {
        // Controleer of er geen vijanden meer in de scène zijn
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            SaveScore(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Herlaad de scène
        }

        // Reset de score als de speler op "N" drukt
        if (Input.GetKeyDown(KeyCode.N))
        {
            ResetScore();
        }
    }

    public void SaveScore()
    {
        // Sla de huidige score op
        PlayerPrefs.SetFloat("score", score); // Sla de huidige score op
    }

    public void ResetScore()
    {
        score = 0;
        SaveScore();
        UpdateUI();
    }

    public void HighScore()
    {
        if(score >= PlayerPrefs.GetFloat("HighScore")) 
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
        }
        
    }

    private void UpdateUI()
    {
        scoreText.text = $"Score: {score}"; // Toon de bijgewerkte score in de UI
    }

    public void IncreaseScore(float amount)
    {
        score += amount; // Verhoog de score met het opgegeven bedrag
        UpdateUI(); // Werk de UI bij om de nieuwe score weer te geven
    }
}
