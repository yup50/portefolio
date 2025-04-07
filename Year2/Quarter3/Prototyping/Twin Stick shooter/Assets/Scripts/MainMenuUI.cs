using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
}
