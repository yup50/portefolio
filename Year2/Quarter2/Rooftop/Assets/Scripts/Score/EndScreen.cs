using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    public TextMeshProUGUI score;
    private ScoreSystem scoreSystem;
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = GameObject.FindAnyObjectByType<ScoreSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (scoreSystem.score >= 0)
        {
            score.text = $"Points: {scoreSystem.score}";
            scoreSystem.score = -1 ;
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Demo");
    }
}
