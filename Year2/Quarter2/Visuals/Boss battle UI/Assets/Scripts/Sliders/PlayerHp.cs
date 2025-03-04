using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    private Slider slider;
    public float maxHp;
    public float currentHp;
    public TextMeshProUGUI hpText;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxHp;
        slider.value = currentHp;
        hpText.text = $"{currentHp}/{maxHp}";
    }

    private void Update()
    {
        if(currentHp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LowerHp(float damage)
    {
        currentHp -= damage;
        UpdateStats();
    }

    public void IncreaseHp(float amount)
    {
        currentHp += amount;
        UpdateStats();
    }

    public void LowerMaxHp(float damage)
    {
        maxHp -= damage;
        UpdateStats();
    }

    public void IncreaseMaxHp(float amount)
    {
        maxHp += amount;
        UpdateStats();
    }

    private void UpdateStats()
    {
        slider.value = currentHp;
        slider.maxValue = maxHp;
        if (currentHp > maxHp) currentHp = maxHp;
        hpText.text = $"{currentHp}/{maxHp}";
    }
}
