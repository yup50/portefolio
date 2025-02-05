using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public ScoreSystem scoreSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            scoreSystem.IncreaseScore(500);
            Destroy(gameObject);
        }
    }
}
