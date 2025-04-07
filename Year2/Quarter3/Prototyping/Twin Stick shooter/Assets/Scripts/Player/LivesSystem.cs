using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesSystem : MonoBehaviour
{
    private int lives;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOverText;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0 && !isDead)
        {
            isDead = true;
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        lives -= damage;
        UpdateUI();
    }

    public void UpdateUI()
    {
        lifeText.text = $" X {lives}";
    }

    private void Die()
    {
        gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        Invoke("Restart", 5);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
