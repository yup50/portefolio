using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    private Slider slider;
    public float neededExp;
    public float currentExp;
    public int lvl;
    public TextMeshProUGUI level;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = neededExp;
        slider.value = currentExp;
        level.text = $"lvl:{lvl}";
    }

    private void Update()
    {
        if (currentExp > neededExp)
        {
            currentExp -= neededExp;
            LevelUp();
        }
    }

    public void increaseExp(float amount)
    {
        currentExp += amount;
        UpdateStats();
    }

    public void LevelUp()
    {
        neededExp = (neededExp * 1.2f);
        lvl++;
        level.text = $"lvl:{lvl}";
        UpdateStats();
    }

    private void UpdateStats()
    {
        slider.value = currentExp;
        slider.maxValue = neededExp;
    }
}
