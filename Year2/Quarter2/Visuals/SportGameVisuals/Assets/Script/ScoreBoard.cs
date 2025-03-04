using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{

    public GameObject team1PreFab;
    public GameObject team2PreFab;

    public GameObject Team1;
    public GameObject Team2;

    public List<GameObject> team1 = new List<GameObject>(); // De lijst voor team1
    public List<GameObject> team2 = new List<GameObject>(); // De lijst voor team2

    private int playerCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (gameObject.GetComponent<CanvasGroup>().alpha == 1.0f)
            {
                gameObject.GetComponent<CanvasGroup>().alpha = 0f;
                return;
            }

            if (gameObject.GetComponent<CanvasGroup>().alpha == 0f)
            {
                gameObject.GetComponent<CanvasGroup>().alpha = 1.0f;
            }
        }
    }

    private void InitializeGame()
    {
        for (int i = 0; i < playerCount; i++) // Loop voor het gewenste aantal spelers
        {
            GameObject newPlayer = Instantiate(team1PreFab); // Instantieer een nieuw prefab-object
            newPlayer.transform.SetParent(Team1.transform); // Voeg het prefab-object toe als een kind van dit object
            newPlayer.name = "Player " + (i + 1); // Optioneel: geef het kind een unieke naam
            newPlayer.GetComponent<PlayerStats>().userName1 = ("bot" + i).ToString();
            team1.Add(newPlayer); // Voeg het nieuwe object toe aan de lijst
        }

        for (int i = 0; i < playerCount; i++) // Loop voor het gewenste aantal spelers
        {
            GameObject newPlayer = Instantiate(team2PreFab); // Instantieer een nieuw prefab-object
            newPlayer.transform.SetParent(Team2.transform); // Voeg het prefab-object toe als een kind van dit object
            newPlayer.name = "Player " + (i + 1); // Optioneel: geef het kind een unieke naam
            newPlayer.GetComponent<PlayerStats>().userName1 = ("enemyBot" + i).ToString();
            team2.Add(newPlayer); // Voeg het nieuwe object toe aan de lijst
        }
    }

    public void AddPlayer(string team)
    {
        if (team == "team1") 
        {
            GameObject newPlayer = Instantiate(team1PreFab); // Instantieer een nieuw prefab-object
            newPlayer.transform.SetParent(Team1.transform); // Voeg het prefab-object toe als een kind van dit object
            newPlayer.name = "Player"; // Optioneel: geef het kind een unieke naam
            newPlayer.GetComponent<PlayerStats>().userName1 = ("botNew").ToString();
            team1.Add(newPlayer); // Voeg het nieuwe object toe aan de lijst
        }
        else
        {
            GameObject newPlayer = Instantiate(team2PreFab); // Instantieer een nieuw prefab-object
            newPlayer.transform.SetParent(Team2.transform); // Voeg het prefab-object toe als een kind van dit object
            newPlayer.name = "Playernew "; // Optioneel: geef het kind een unieke naam
            newPlayer.GetComponent<PlayerStats>().userName1 = ("enemyBotNew").ToString();
            team2.Add(newPlayer); // Voeg het nieuwe object toe aan de lijst
        }
        SortPlayersByGoals();
    }

    public void SortPlayersByGoals()
    {
        team1 = team1.OrderByDescending(p => p.GetComponent<PlayerStats>().goals1).ToList();

        // Update de volgorde van de UI
        for (int i = 0; i < team1.Count; i++)
        {
            // Haal het UI-object van de speler op
            GameObject player = team1[i];

            // Stel de volgorde in op basis van de gesorteerde lijst
            player.transform.SetSiblingIndex(i);
        }
        team2 = team2.OrderByDescending(p => p.GetComponent<PlayerStats>().goals1).ToList();
        for (int i = 0; i < team2.Count; i++)
        {
            // Haal het UI-object van de speler op
            GameObject player = team2[i];

            // Stel de volgorde in op basis van de gesorteerde lijst
            player.transform.SetSiblingIndex(i);
        }

        //UpdateScoreboardUI(team1);

    }

    public void UpdateScoreboardUI(List<GameObject> sortedPlayers)
    {
        if(sortedPlayers == team1)
        {
            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                GameObject player = sortedPlayers[i];

                // Verplaats het corresponderende UI-element in de juiste volgorde
                player.transform.SetSiblingIndex(i);

                // Update de tekst (optioneel, alleen nodig als gegevens ook veranderen)
                PlayerStats stats = player.GetComponent<PlayerStats>();
            }
        }
        

    }
}
