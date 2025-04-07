using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int maxEnergy = 5, energyRechargeDuration = 5;
    public float energyTimer = 0;


    [SerializeField]
    private NotificationManager notificationManager;

    [SerializeField]
    private static int energy;

    private const string energyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";
    public TextMeshProUGUI energyDisplay;

    private void Start()
    {
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

    //Recharges Energy and Send Push Notification when energy is fully charged
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && energy > 0 && !EventSystem.current.IsPointerOverGameObject() && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            energy--;
            PlayerPrefs.SetInt(energyKey, energy);
            UpdateEnergyUI();

            if (energy == 0)
            {
                DateTime energyReady = DateTime.Now.AddSeconds(energyRechargeDuration);
                PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
                //notificationHandler.ScheduleNotification(energyReady);
#if UNITY_ANDROID
                AndroidNotificationCenter.CancelAllNotifications();
                notificationManager.androidNotifications.SendNotification("Full Energy!", "Your ENERGY has been fully recharged!", 10);
#endif
#if UNITY_IOS
                iOSNotificationCenter.RemoveAllScheduledNotifications();
                notificationManager.iosNotifications.SendNotification("Full Energy!", "Your ENERGY has been fully recharged!", "Come back and play!!", 10);
#endif
            }

            SceneManager.LoadScene(1);
        }

        if (energy < maxEnergy)
        {
            energyTimer += Time.deltaTime; // Timer verhogen

            if (energyTimer >= energyRechargeDuration)
            {
                Debug.Log("Ik werk");
                energy++; // Voeg 1 energy toe
                energyTimer = 0f; // Reset timer
                PlayerPrefs.SetInt(energyKey, energy);
                UpdateEnergyUI();
            }
        }
    }
}