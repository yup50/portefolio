using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public void GameTime(float x)
    {
        PlayerPrefs.SetString("tutorial", "True");
        Time.timeScale = x;
    }
}
