using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortScript : MonoBehaviour
{
    public Transform inventorySlots;

    public void Sort(string input)
    {
        List<InventoryItem> children = new List<InventoryItem>();

        foreach (Transform child in inventorySlots)
        {
            InventoryItem item = child.GetComponent<InventoryItem>();
            if (item != null)
                children.Add(item);
        }

        // Dynamisch sorteren op basis van string input
        switch (input.ToLower())
        {
            case "name":
                children.Sort((a, b) =>
                {
                    string nameA = a.item != null ? a.item.itemName : "";
                    string nameB = b.item != null ? b.item.itemName : "";
                    return nameB.CompareTo(nameA);
                });
                break;
            case "amount":
                children.Sort((a, b) => b.amount.CompareTo(a.amount));
                break;
            default:
                Debug.LogWarning("Onbekend sorteercriterium: " + input);
                return;
        }

        for (int i = 0; i < children.Count; i++)
        {
            children[i].transform.SetSiblingIndex(i);
        }
    }

}
