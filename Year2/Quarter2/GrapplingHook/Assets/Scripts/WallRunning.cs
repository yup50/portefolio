using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRunning : MonoBehaviour
{
    public enum Side { left, right};
    public Side side;

    public PlayerMovement playerMovement;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<WallRunWall>())
        {
            playerMovement.wallRunning = true;
            playerMovement.wallSide = $"{side}";
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.GetComponent<WallRunWall>())
        {
            playerMovement.wallRunning = false;
            playerMovement.wallSide = "";

        }
    }

}
