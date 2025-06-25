// GameDev.tv Challenge Club. Got questions or want to share your nifty solution?
// Head over to - http://community.gamedev.tv 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour
{
    [SerializeField] private GameObject youWinText = null;

    [SerializeField] private List<PlayerMovement> allPlayerCubes = new List<PlayerMovement>();

    private void Start()
    {
        allPlayerCubes.AddRange(FindObjectsOfType<PlayerMovement>());
    }

    public void RemovePlayerCubeFromList(PlayerMovement thisCube)
    {
        allPlayerCubes.Remove(thisCube);
        CheckIfLevelComplete();
    }

    private void CheckIfLevelComplete()
    {
        if(allPlayerCubes.Count < 1)
        {
            youWinText.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
