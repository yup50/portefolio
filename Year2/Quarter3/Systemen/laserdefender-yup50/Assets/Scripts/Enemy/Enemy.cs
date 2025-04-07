using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float hp = 1; // Hoeveelheid levens van de vijand
    [SerializeField]
    protected float scorePoints = 100; // Punten die de speler krijgt bij het verslaan van deze vijand
    [SerializeField]
    protected ScoreSystem scoreS; // Referentie naar het score-systeem

    protected void Start()
    {
        // Zoek het ScoreSystem als het niet handmatig is ingesteld
        if (scoreS == null)
            scoreS = GameObject.FindGameObjectWithTag("Manager").GetComponent<ScoreSystem>();
    }

    // Methode om schade toe te brengen aan de vijand
    public virtual void TakeDamage(float damage)
    {
        hp -= damage; // Verminder de HP

        if (hp <= 0) // Als de HP op is, sterft de vijand
        {
            Die();
        }
    }

    // Methode om de vijand te vernietigen
    protected void Die()
    {
        scoreS.IncreaseScore(scorePoints); // Voeg punten toe aan de score
        gameObject.SetActive(false); // Deactiveer de vijand
    }
}
