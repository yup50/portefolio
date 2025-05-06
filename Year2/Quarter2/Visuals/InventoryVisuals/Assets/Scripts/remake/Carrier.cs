using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Carrier : MonoBehaviour
{
    public ItemSO item;
    public int amount;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI amountText;
    public Image icon;

    private void Start()
    {
        GetComponent<CanvasGroup>().alpha = 0;
    }
    private void Update()
    {
        gameObject.transform.position = Input.mousePosition;
        if (item == null && GetComponent<CanvasGroup>().alpha == 0.5f)
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }
        else if (item != null && GetComponent<CanvasGroup>().alpha == 0)
        {
            GetComponent<CanvasGroup>().alpha = 0.5f;
        }
    }

    public void SetData(ItemSO item, int itemAmount)
    {
        this.item = item;
        amount = itemAmount;

        nameText.text = item.itemName;
        amountText.text = itemAmount.ToString();
        icon.sprite = item.icon;
    }

    public void Reset()
    {
        item = null;
    }
}
