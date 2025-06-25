using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        transform.position = pos;
    }
    private void OnTriggerEnter() 
    {
        SceneManager.LoadScene(0);
    }
}
