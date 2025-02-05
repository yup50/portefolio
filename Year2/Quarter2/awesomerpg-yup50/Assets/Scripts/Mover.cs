using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimator();
    }

    public void StartMove(Vector3 destination)
    {
        GetComponent<Fighter>().Cancel();
        Move(destination);
    }

    public void Move(Vector3 destination)
    {
        navMeshAgent.destination = destination;
        navMeshAgent.isStopped = false;
    }

    public void Stop()
    {
        navMeshAgent.isStopped = true;
    }

    void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        if(GetComponent<PlayerController>()) GetComponentInChildren<Animator>().SetFloat("forwardSpeed", speed);

    }
}
