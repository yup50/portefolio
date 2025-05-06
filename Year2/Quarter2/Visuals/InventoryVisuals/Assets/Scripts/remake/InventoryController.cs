using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryController : MonoBehaviour
{
    public GameObject inventory; //the entire inventory
    public GameObject inventoryItem; //the slots of the inventory
    public ItemSO testItem, testItem2, testItem3;

    public Transform itemContent; //parent of all the slots
    [SerializeField]
    public List<InventoryItem> items = new List<InventoryItem>(); //list of the slots
    
    [Header("description")]
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in itemContent)
        {
            Destroy(child.gameObject);
        }

        for(int i = 0; i < items.Count; i++)
        {
            GameObject newItem = Instantiate(inventoryItem, itemContent); // Spawnt als kind van itemContent
            items[i] = inventoryItem.GetComponent<InventoryItem>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddItem(testItem, testItem.itemAmount);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AddItem(testItem2, testItem2.itemAmount);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddItem(testItem3, testItem3.itemAmount);
        }

    }

    private void Inventory()
    {
        inventory.SetActive(!inventory.activeSelf);
    }

    public void AddItem(ItemSO testItem, int itemAmount)
    {
        foreach (Transform child in itemContent)
        {
            InventoryItem invItem = child.GetComponent<InventoryItem>();
            if (invItem.item == testItem && invItem.amount < invItem.item.stacksize)
            {
                invItem.IncreaseItem(testItem, testItem.itemAmount);
                return;
            }
            else if (invItem.item == null)
            {
                invItem.SetItem(testItem, itemAmount);
                return;
            }
        }
    }
}
