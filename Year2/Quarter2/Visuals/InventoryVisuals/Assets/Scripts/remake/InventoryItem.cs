using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler
{
    public InventoryController invController;
    public ItemSO item;
    public int amount;
    public TextMeshProUGUI amountText;
    public Image img;
    public TextMeshProUGUI itemName;

    [Header("carrier")]
    private Carrier carrier;

    

    private void Start()
    {
        invController = GetComponentInParent<InventoryController>();
        carrier = GameObject.FindGameObjectWithTag("Carrier").GetComponent<Carrier>();
    }

    // Start is called before the first frame update

    public void SetItem(ItemSO newItem, int itemAmount)
    {
        if (itemAmount == 0) return;
        item = newItem;

        if (item != null)
        {
            img.gameObject.SetActive(true);
            amount = itemAmount;
            img.sprite = item.icon;
            UpdateUI();
        }
        else
        {
            Reset();
        }
    }

    public void IncreaseItem(ItemSO newItem, int itemAmount)
    {
            amount += itemAmount;
            int x = amount - item.stacksize;
            if(x > 0)
            {
                amount = item.stacksize;
                invController.AddItem(newItem, x);
            }
            UpdateUI();
    }

    private void UpdateUI()
    {
        amountText.text = amount.ToString();
        itemName.text = item.itemName;
    }

    public void Reset()
    {
        item = null;
        itemName.text = "";
        amountText.text = "";
        amount = 0;
        img.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(item != null)
        {
            carrier.SetData(item, amount);
            img.gameObject.SetActive(false);
            Reset();
        }
    }

   public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            InventoryItem targetSlot = eventData.pointerEnter.GetComponent<InventoryItem>(); //checks for inventoryslot on pointer position
            EquipmentSlots equipSlot = eventData.pointerEnter.GetComponent<EquipmentSlots>(); //checks for equipmentslot on pointer position

            Debug.Log("Ik werk ook");
            if (equipSlot != null )// is the slot a equipmentSlot
            {
                if (carrier.item.itemType == equipSlot.itemType) //is the item being dragged the dame type as the slot type
                {
                    Debug.Log("Ik werk ook");
                    equipSlot.SetItem(carrier.item);
                    carrier.amount--;
                }
                else
                {
                    Debug.Log("Item past hier niet");
                }
                    SetItem(carrier.item, carrier.amount);
            }
            else if (targetSlot != null && targetSlot.item == null) //is it a enmpty inventory slot
            {

                targetSlot.SetItem(carrier.item, carrier.amount);

            }else if(targetSlot != null) //is it a slot that already has an item
            {

                if(targetSlot.item == carrier.item)//the same item in the slot
                {
                    targetSlot.IncreaseItem(carrier.item, carrier.amount);
                }
                else //different item already in slot
                {
                    SetItem(targetSlot.item, targetSlot.amount);
                    targetSlot.SetItem(carrier.item, carrier.amount);
                }

            }
            else
            {
                SetItem(carrier.item, carrier.amount);
            }
                carrier.Reset();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(item != null)
        {
            invController.title.text = item.itemName;
            invController.description.text = item.description;
        }
    }
}
