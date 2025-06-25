using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv

public class Bounce : MonoBehaviour
{
    [SerializeField] float jumpForce = 20;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    void JumpyJumpy(Collider other)
    {

    }
}
