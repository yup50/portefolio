using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BallControlScript))]


public class DragLaunch : MonoBehaviour
{
    private BallControlScript ballControlScript;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    private void Start()
    {
        ballControlScript = GetComponent<BallControlScript>();
    }
    
    public void DragStart()
    {
        dragStart = Input.mousePosition;
        startTime = Time.time;

    }

    public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;

        float launchSpeedX = (dragEnd.x - dragStart.x)/dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y)/dragDuration;

        if( launchSpeedX > 30)
        {
            launchSpeedX = 30;
        }else if (launchSpeedX < -30)
        {
            launchSpeedX = -30;
        }
        if ( launchSpeedZ > 300)
        {
            launchSpeedZ = 300;
        }

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

        if( launchVelocity.z > 0)
        {
            ballControlScript.Launch(launchVelocity);
        }

    }
}
