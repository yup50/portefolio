using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading;

public class EquipmentSlots : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public string itemType;
    public ItemSO item;
    public Image img;

    private Carrier carrier;

    private void Start()
    {
        carrier = GameObject.FindGameObjectWithTag("Carrier").GetComponent<Carrier>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            carrier.SetData(item, 1);
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

            if (equipSlot != null)// is the slot a equipmentSlot
            {
                if (carrier.item.itemType == equipSlot.itemType) //is the item being dragged the dame type as the slot type
                {
                    equipSlot.SetItem(carrier.item);
                    carrier.amount--;
                }
                else
                {
                    Debug.Log("Item past hier niet");
                }
                SetItem(carrier.item);
            }
            else if (targetSlot != null && targetSlot.item == null) //is it a enmpty inventory slot
            {

                targetSlot.SetItem(carrier.item, carrier.amount);

            }
            else if (targetSlot != null) //is it a slot that already has an item
            {

                if (targetSlot.item == carrier.item)//the same item in the slot
                {
                    targetSlot.IncreaseItem(carrier.item, carrier.amount);
                }
                else //different item already in slot
                {
                    targetSlot.invController.AddItem(carrier.item, 1);
                }

            }
            else
            {
                SetItem(carrier.item);
            }
            carrier.Reset();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    private void Reset()
    {
        item = null;
        img.gameObject.SetActive(false);
    }

    public void SetItem(ItemSO item)
    {
        img.gameObject.SetActive(true);
        this.item = item;
        img.sprite = this.item.icon;
    }
}
