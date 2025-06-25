using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    [SerializeField] ParticleSystem celebration;
    bool hasChildren = true;

    void Update()
    {
        if (transform.childCount == 0 && hasChildren)
        {
            hasChildren = false;
            celebration.Play();
        }
    }
}
