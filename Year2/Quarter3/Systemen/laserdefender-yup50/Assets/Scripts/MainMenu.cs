using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public bool tutorial;

    [SerializeField]
    private int maxEnergy = 5, energyRechargeDuration = 5;
    public float energyTimer = 0;


    //[SerializeField]
    //private NotificationManager notificationManager;

    [SerializeField]
    private static int energy;

    private const string energyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";
    public TextMeshProUGUI energyDisplay;

    private void Start()
    {
        highScore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore").ToString();

        energy = PlayerPrefs.GetInt(energyKey, maxEnergy);

        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);

            if (energyReadyString == string.Empty)
            {
                return;
            }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(energyKey, energy);
            }
            else
            {
                Invoke("EnergyRecharged", (energyReady - DateTime.Now).Seconds);
            }
        }
        UpdateEnergyUI();
    }

    void Update()
    {
        if (energy < maxEnergy)
        {
            energyTimer += Time.deltaTime;

            if (energyTimer >= energyRechargeDuration)
            {
                energy++;
                energyTimer = 0f;
                PlayerPrefs.SetInt(energyKey, energy);
                UpdateEnergyUI();
            }
        }
    }

    public void StartGame()
    {
        if(energy > 0)
        {
            energy--;
            PlayerPrefs.SetInt(energyKey, energy);
            UpdateEnergyUI();

            if (energy == 0)
            {
                DateTime energyReady = DateTime.Now.AddSeconds(energyRechargeDuration);
                PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
            }
            PlayerPrefs.SetString("tutorial", tutorial.ToString());
            SceneManager.LoadScene("LaserShooter");
            Debug.Log(PlayerPrefs.GetString("tutorial"));
        }
        

        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetTutorial(bool value)
    {
        tutorial = value;
        Debug.Log(value);
    }

    private void UpdateEnergyUI()
    {
        energyDisplay.text = $"Energy: {energy}/5";
    }

    public void EnergyRecharged()
    {
        energy = maxEnergy;
        PlayerPrefs.SetInt(energyKey, energy);
        UpdateEnergyUI();
    }
}
