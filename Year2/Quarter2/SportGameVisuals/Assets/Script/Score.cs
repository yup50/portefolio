using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI team1Score, team2Score;
    public int team1Goals;
    public int team2Goals;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void UpdateScore()
    {
        team1Goals = 0;
        team2Goals = 0;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            team1Goals += player.GetComponent<PlayerStats>().goals1;
    
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            team2Goals += enemy.GetComponent<PlayerStats>().goals1;
        }
        team1Score.text = team1Goals.ToString();
        team2Score.text = team2Goals.ToString();
    }
}
