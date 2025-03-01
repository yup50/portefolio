using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingTreshold = 360f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = MathF.Abs(rotationInEuler.x);
        float tiltInZ = MathF.Abs(rotationInEuler.z);

        if (tiltInX < (standingTreshold-93) || tiltInZ < standingTreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
