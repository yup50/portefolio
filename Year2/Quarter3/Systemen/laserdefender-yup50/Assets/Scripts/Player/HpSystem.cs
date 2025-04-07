using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HpSystem : MonoBehaviour
{
    [SerializeField]
    private float hp = 3; // Start hoeveelheid HP

    [SerializeField]
    private ScoreSystem ss;
    public AudioClip hitSound; // Geluid bij schade

    private IGeluid _geluid; // Verwijzing naar een geluidsmanager

    private void Start()
    {
        _geluid = FindObjectOfType<AudioManager>(); // Zoek een instantie van een AudioManager
        ss = GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreSystem>();

    }

    void Update()
    {
        // Controleer of de speler dood is en pauzeer het spel
        if (hp <= 0)
        {
            ss.HighScore();
            SceneManager.LoadScene("Main Menu");
        }
    }

    // Herstart de scène en zet de tijdschaal terug
    private void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Verminder HP bij schade en speel geluid af als beschikbaar
    public void TakeDamage(float damage)
    {
        if (hitSound != null && damage > 0) _geluid?.SpeelGeluidAf(hitSound);
        hp -= damage;
    }

    // Geeft de huidige HP terug
    public float Hp()
    {
        return hp;
    }
}
