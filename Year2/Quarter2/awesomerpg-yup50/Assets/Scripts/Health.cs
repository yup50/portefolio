using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private float healthPoints = 100f;
    private bool isDead = false;
    [SerializeField] private Slider healthBar;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI hpValue;

    private void Start()
    {
        if (gameObject.tag == "Player") gameOverScreen.SetActive(false);
        healthBar.maxValue = healthPoints; //dit wordt iets als healthBar.maxValue = BaseStat.GetStat(Stats.Health)
        healthBar.value = healthPoints;
        UpdateHealthBar();
    }

    private void Update()
    {
        
    }
    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);

        if(healthPoints == 0)
        {
            Die();
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.value = healthPoints;
        hpValue.text = $"{healthPoints}/{healthBar.maxValue}  {Mathf.RoundToInt((healthPoints / healthBar.maxValue) * 100)}%";
    }

    public void Die()
    {
        isDead = true;
        if(gameObject.tag == "Player")
        {
            gameOverScreen.SetActive(true);
            GetComponentInChildren<Animator>().SetTrigger("die");
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
