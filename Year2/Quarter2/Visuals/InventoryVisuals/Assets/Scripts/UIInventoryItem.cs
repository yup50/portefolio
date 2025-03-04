using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using Inventory.Model;

namespace Inventory.UI
{

    public class UIInventoryItem : MonoBehaviour, IPointerClickHandler,
        IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
        [SerializeField]
        public Image itemImage;
        [SerializeField]
        public TextMeshProUGUI quantityTxt;
        public int thisQuantity;

        public ItemSO.ItemType itemType;

        [SerializeField]

        public event Action<UIInventoryItem> OnItemClicked,
            OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag,
            OnRightMouseBtnClick;

        private bool empty = true;

        public void Awake()
        {
            ResetData();
        }
        public void ResetData()
        {
            itemImage.gameObject.SetActive(false);
            itemType = ItemSO.ItemType.alles;
            thisQuantity = 0;
            empty = true;
        }

        public void SetData(Sprite sprite, int quantity, ItemSO.ItemType type)
        {
                itemImage.sprite = sprite;
                itemImage.gameObject.SetActive(true);
                quantityTxt.text = $"{quantity}";
                thisQuantity = quantity;
                itemType = type;
                empty = false;
                
        }



        public void OnBeginDrag(PointerEventData eventData)
        {
            if (empty)
                return;
            OnItemBeginDrag?.Invoke(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            OnItemDroppedOn?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {

            OnItemEndDrag?.Invoke(this);
        }


        public void OnPointerClick(PointerEventData pointerData)
        {
            if (pointerData.button == PointerEventData.InputButton.Right)
            {
                OnRightMouseBtnClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {

        }
    }
}