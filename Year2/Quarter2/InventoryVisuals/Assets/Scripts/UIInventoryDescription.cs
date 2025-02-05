using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Inventory.UI
{
    public class UIInventoryDescription : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text title;
        [SerializeField]
        private TMP_Text description;


        public void Awake()
        {
            ResetDescription();
        }

        public void ResetDescription()
        {
            title.text = "";
            description.text = "";
        }

        public void SetDescription(Sprite sprite, string itemName,
            string itemDescription)
        {
            title.text = itemName;
            description.text = itemDescription;
        }
    }
}