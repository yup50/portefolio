using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI klok; // UI-element om de tijd weer te geven
    private float remainingTime = 90 * 60; // 90 minuten in seconden
    public bool isGameRunning = false; // Om te controleren of de klok actief moet aftellen

    // Start is called before the first frame update
    void Start()
    {
        StartClock(); // Start de klok wanneer het spel begint
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameRunning)
        {
            UpdateClock();
        }
    }

    public void StartClock()
    {
        isGameRunning = true;
    }

    public void PauseClock()
    {
        isGameRunning = false;
    }

    private void UpdateClock()
    {
        if (remainingTime > 0 && isGameRunning)
        {
            // Verminder de resterende tijd
            remainingTime -= Time.deltaTime;

            // Bereken minuten en seconden
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);

            // Update de UI
            klok.text = $"{minutes:D2}:{seconds:D2}";
        }
        else
        {
            // Stop de klok als de tijd op is
            PauseClock();
        }
    }
}
