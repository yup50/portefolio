using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public string key;
    void OnEnable()
    {
        if (PlayerPrefs.GetString("tutorial") == "False" || PlayerPrefs.GetString("phoneCheck") == key)
        {
            gameObject.SetActive(false);
        }   
    }
}


