using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatAI : MonoBehaviour
{
    private float moveSpeed = 20f;          
    private float dangerHeight = 5f;       
    private float safeDistance = 3f;       
    private float ballDetectionRange = 15f; 

    private GameObject targetBall;        
    private GameObject targetBomb;       

    void Update()
    {
        FindBomb();
        
        FindBall();

        if (targetBomb != null)
        {
            AvoidBomb();
        }
        else if (targetBall != null)
        {
            MoveTowards(targetBall.transform.position);
        }
    }

    void FindBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        targetBall = null; 

        foreach (GameObject ball in balls)
        {
            if (Vector3.Distance(transform.position, ball.transform.position) <= ballDetectionRange)
            {
                targetBall = ball;
                break; 
            }
        }
    }

    void FindBomb()
    {
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
        targetBomb = null; 

        foreach (GameObject bomb in bombs)
        {
            if (bomb.transform.position.y < dangerHeight && Mathf.Abs(bomb.transform.position.x - transform.position.x) <= safeDistance)
            {
                targetBomb = bomb;
                break; 
            }
        }
    }

    void AvoidBomb()
    {
        if (targetBomb != null)
        {
            float moveDirection = targetBomb.transform.position.x > transform.position.x ? -1 : 1;
            Move(moveDirection);
        }
    }

    void MoveTowards(Vector3 targetPosition)
    {
        float moveDirection = targetPosition.x > transform.position.x ? 1 : -1;
        Move(moveDirection);
    }

    void Move(float direction)
    {
        Vector3 newPosition = transform.position + new Vector3(direction, 0, 0) * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);
    }
}
