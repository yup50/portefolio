using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.RestService;
using System.Linq;

public class PlayerStats : MonoBehaviour
{
    public TextMeshProUGUI userName;
    public string userName1;
    
    public TextMeshProUGUI goals;
    public int goals1;
    
    public TextMeshProUGUI assists;
    public int assists1;
    
    public TextMeshProUGUI fouls;
    public int fouls1;

    float time = 1f;

    public Score score;
    private ScoreBoard scoreBoard;
    public Clock clock;
    //Voor als ik met scriptable objects wil werken
    //public PlayerDataFileLocator playerData;

    // Start is called before the first frame update
    void Start()
    {
        UpdatePlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (score == null) score = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>();
        if (scoreBoard == null) scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoreBoard>();
        if (clock == null) clock = GameObject.FindGameObjectWithTag("Clock").GetComponent<Clock>();

        if (this.fouls1 >= 3) BanPlayer();



        if (Input.GetKeyDown(KeyCode.E) && time <= 0 && clock.isGameRunning)
        {
            Goal();
            time = 1;
        }
    }

    public void Goal()
    {
        PlayerStats scoringPlayer = this;
        scoringPlayer.goals1 += Random.Range(0, 2);
        UpdateStuff();
    }

    public void IncreaseFoul()
    {
        if (clock.isGameRunning)
        {
            this.fouls1++;
            UpdateStuff();
        }
    }
    
    public void BanPlayer()
    {
        if(this.gameObject.tag == "Player")
        {
            scoreBoard.AddPlayer("team1");
        }
        else
        {
            scoreBoard.AddPlayer("team2");
        }
        Destroy(this.gameObject);
    }
    private void UpdateStuff()
    {
        UpdatePlayerStats();
        score.UpdateScore();
        scoreBoard.SortPlayersByGoals();
    }

    public void UpdatePlayerStats()
    {
        userName.text = userName1;
        goals.text = goals1.ToString();
        assists.text = assists1.ToString();
        fouls.text = fouls1.ToString();
    }

}
