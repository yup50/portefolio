// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour
{
    private GameHandler gameHandler;

    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if(collision.gameObject.GetComponent<ColorChanger>().color == GetComponent<ColorChanger>().color)
            {
                return;
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //eenvoudige herstart methode
            }
        }
    }
}
