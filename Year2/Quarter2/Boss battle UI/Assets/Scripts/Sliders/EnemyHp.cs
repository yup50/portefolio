using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    private Slider slider;
    private Exp exp;
    public float maxHp;
    public float currentHp;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxHp;
        slider.value = currentHp;
        exp = GameObject.FindAnyObjectByType<Exp>();
    }

    private void Update()
    {
        if (currentHp > maxHp) currentHp = maxHp;
        if (currentHp <= 0)
        {
            exp.increaseExp(50);
            currentHp = maxHp;
            UpdateStats();
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
    }
}
