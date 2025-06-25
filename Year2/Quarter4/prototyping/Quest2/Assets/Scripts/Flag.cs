using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool canWin;


    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        text.text = $"Coins left:{FindObjectsByType<Coin>(FindObjectsSortMode.None).Count()}/16";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.gameObject.GetComponent<ColorChanger>().color == GetComponent<ColorChanger>().color && WinCondition())
            {
                Destroy(gameObject);
            }
        }
    }

    private bool WinCondition() //aangezien ik maar 1 level maak kan ik gewoon deze functie aanpassen maar anders had ik deze in een extensie geplaatst
    {
        if (FindObjectsByType<Coin>(FindObjectsSortMode.None).Count() == 0) return true;
        else return false;
    }
}
