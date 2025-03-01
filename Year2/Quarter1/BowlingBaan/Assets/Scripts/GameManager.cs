using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;  //instance

    public TextMeshProUGUI scoreText;
    private int score = 0;
    public int scoreDoubler = 0;

    public int buffer1;
    public int buffer2;

    public List<int> rolls;
    private bool canRoll;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        rolls = new List<int>();
        canRoll = false;
    }

    public void ChangeCanRoll(int value)
    {
        canRoll = (value != 0);
    }

    public bool CanRoll()
    {
        return canRoll;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {score}";
    }

    public void IncreaseScore(int scoreValue)
    {
        rolls.Add(scoreValue);

        // Check of de vorige worpen een strike of spare waren
        int rollCount = rolls.Count;

        if (rollCount >= 5 && rolls[rollCount - 4] == 10 && scoreValue == 10)
        {
            score += scoreValue;
        }

        // Check op strike bonus (twee worpen geleden
        if (rollCount >= 3 && rolls[rollCount - 2] == 10)
        {
            score += scoreValue;
        }
        if (rollCount >= 2 && (rolls[rollCount - 2] + rolls[rollCount - 1] == 10))
        {
            score += scoreValue; // Voeg de huidige worp toe als bonus voor de spare
        }
        // Voeg de huidige score toe
        score += scoreValue;

    }
}
