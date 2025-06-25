// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private BlockMovement[] allPlayerBlocks;
    public GameObject victory;

    void Start()
    {
        AllPlayerBlocksArrayUpdate();
        if (victory.activeSelf == true) victory.SetActive(false);
    }

    void Update()
    {
        BlockSelection();
        if (FindObjectsByType<Flag>(FindObjectsSortMode.None).Length == 0)
        {
            Time.timeScale = 0;
            victory.SetActive(true);
        }
    }

    private void BlockSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActiveBlockPlusOne();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ActiveBlockMinusOne();
        }
    }

    public void AllPlayerBlocksArrayUpdate()
    {
        allPlayerBlocks = FindObjectsOfType<BlockMovement>();
    }

    public void DestroyedBlockUpdate()
    {
        ActiveBlockPlusOne();
    }

    private void ActiveBlockPlusOne()
    {
        AllPlayerBlocksArrayUpdate();


        for (int i = 0; i < allPlayerBlocks.Length; i++)
        {
            if (allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool)
            {
                allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool = false;

                if (i < allPlayerBlocks.Length - 1)
                {
                    allPlayerBlocks[i + 1].GetComponent<BlockMovement>().isActiveBool = true;
                    break;

                }
                else
                {
                    allPlayerBlocks[0].GetComponent<BlockMovement>().isActiveBool = true;
                    break;
                }
            }
        }
    }

    private void ActiveBlockMinusOne()
    {
        AllPlayerBlocksArrayUpdate();

        for (int i = 0; i < allPlayerBlocks.Length; i++)
        {
            if (allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool)
            {
                allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool = false;

                if (i >= 1)
                {
                    allPlayerBlocks[i - 1].GetComponent<BlockMovement>().isActiveBool = true;
                    break;

                }
                else
                {
                    allPlayerBlocks[allPlayerBlocks.Length - 1].GetComponent<BlockMovement>().isActiveBool = true;
                    break;
                }
            }
        }
    }
}
