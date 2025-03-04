using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Inventory.Model
{


[CreateAssetMenu]


public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<InventoryItem> inventoryItems;

    [field: SerializeField]
    public int Size { get; private set; } = 30;

    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdated;


    public void Initialize()
    {
        inventoryItems = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            inventoryItems.Add(InventoryItem.GetEmptyItem());
        }
    }

    public InventoryItem GetItemAt(int itemIndex)
    {
            return inventoryItems[itemIndex];
    }

    public void AddItem(ItemSO item, int quantity)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                inventoryItems[i] = new InventoryItem
                {
                    item = item,
                    quantity = quantity,
                };
                return;
            }
        }
    }

    public void AddItem(InventoryItem item)
    {
        AddItem(item.item, item.quantity);
    }

    public void SwapItems(int itemIndex_1, int itemIndex_2)
    {
        InventoryItem item1 = inventoryItems[itemIndex_1];
        inventoryItems[itemIndex_1] = inventoryItems[itemIndex_2];
        inventoryItems[itemIndex_2] = item1;
        InformAboutChange();
    }

    private void InformAboutChange()
    {
        OnInventoryUpdated?.Invoke(GetCurrentInventoryState());
    }

    public Dictionary<int, InventoryItem> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem> returnValue =
            new Dictionary<int, InventoryItem>();

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
                continue;
            returnValue[i] = inventoryItems[i];
        }
        return returnValue;
    }

        public void SortByQuantity()
        {
            inventoryItems.Sort((item1, item2) => item2.quantity.CompareTo(item1.quantity));
            InformAboutChange();
        }

        public void SortByType()
        {
            inventoryItems.Sort((item1, item2) =>
            {
                if (item1.IsEmpty && item2.IsEmpty) return 0;
                if (item1.IsEmpty) return 1; // Lege items naar het einde
                if (item2.IsEmpty) return -1;

                return item1.itemType.ToString().CompareTo(item2.itemType.ToString());
            });
            InformAboutChange();
        }
    }

[Serializable]
public struct InventoryItem
{
    public int quantity;
    public ItemSO item;
    public ItemSO.ItemType itemType;
    public bool IsEmpty => item == null;

    public InventoryItem ChangeQuantity(int newQuantity)
    {
        return new InventoryItem
        {
            item = this.item,
            quantity = newQuantity,
        };
    }

    public static InventoryItem GetEmptyItem()
        => new InventoryItem
        {
            item = null,
            quantity = 0,
        };
}
}