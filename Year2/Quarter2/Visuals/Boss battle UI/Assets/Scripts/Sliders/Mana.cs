using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    private Slider slider;
    public float maxMana;
    public float currentMana;
    public TextMeshProUGUI manaText;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxMana;
        slider.value = currentMana;
        manaText.text = $"{currentMana}/{maxMana}";
    }

    private void Update()
    {
    }

    public void LowerMana(float damage)
    {
        currentMana -= damage;
        UpdateStats(1);
    }

    public void IncreaseMana(float amount)
    {
        currentMana += amount;
        UpdateStats(1);
    }

    public void LowerMaxMana(float damage)
    {
        maxMana -= damage;
        UpdateStats(2);
    }

    public void IncreaseMaxMana(float amount)
    {
        maxMana += amount;
        UpdateStats(2);
    }

    private void UpdateStats(int id)
    {
        if(id == 1) slider.value = currentMana;
        if(id == 2) slider.maxValue = maxMana;
        if (currentMana > maxMana) currentMana = maxMana;
        manaText.text = $"{currentMana}/{maxMana}";
    }
}
