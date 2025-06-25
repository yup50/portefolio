using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI distanceText;
    private GameObject player;

    private int score;
    public Light light1;
    public Light light2;
    private float distanceNeed = 200;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceText.text = $"{Mathf.RoundToInt(player.transform.position.x)}m";

        if(player.transform.position.x >= distanceNeed)
        {
            distanceNeed += 200;
            if(light1.gameObject.activeSelf == true)
            {
                light1.gameObject.SetActive(false);
                light2.gameObject.SetActive(false);
            }
            else
            {
                light1.gameObject.SetActive(true);
                light2.gameObject.SetActive(true);
            }
        }
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = $"Score: {score}";
    }
}
